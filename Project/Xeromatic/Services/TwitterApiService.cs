using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;
using Tweet = Xeromatic.Models.Tweet;
using Xeromatic.Services;


namespace Xeromatic.Services
{
    public class TwitterApiService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "2It9jxXfBg00eazrlSF0rv0pI",
                ConsumerSecret = "g1aKfmizybFCVY9l8EtuIeYJ7oHIvUWG8pJ5fjRxzd6YR93ydh",
                AccessToken = "113949626-g7dqvgK0j1xvns8vE9BJRDFtkzwwNoTJemDuFGj7",
                AccessTokenSecret = "nVHoX382AF8OKnxFpZaTNOCw4Obc0G4mXVZzFXZ4k9IFI"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("xero", 10)).ToList();

            if (tweets.Any())
            {
                return tweets.Select(t => new Tweet
                {
                    Id = t.Id,
                    Text = t.Text
                });
            }

            return new List<Tweet>();
        }
    }
}