    public class FeedItemController : ApiController
    {
        private LynxFeedAPI_Context db = new LynxFeedAPI_Context();
        // GET api/FeedItem
        public IQueryable<FeedItem> GetFeedItems()
        {
            return db.FeedItems;
        }
