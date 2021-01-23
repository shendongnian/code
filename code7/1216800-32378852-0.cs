    public class TweetEntityComparer<TweetEntity> 
    {
        public bool Equals(TweetEntity x, TweetEntity y)
        {
            //Determine if they're equal
        }
        public int GetHashCode(TweetEntity obj)
        {
            //Implementation
        }
    }
    List<TweetEntity> tweetEntity = tweetEntity1.Concat(tweetEntity2).Distinct().ToList();
