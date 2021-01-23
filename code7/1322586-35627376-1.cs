    public class Class1TestController
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var feeds = db.Feeds.Select(itm=>new FeedDisplayModel(itm)).ToList();
                return View(feeds);
            }
        }
    }
    class Feed
    {
        public DateTime Created { get; set; }
        public int Id { get; set;}
        public string Message { get; set;}
    }
    class FeedDisplayModel : Feed
    {
        public string Ago { get { return Created.TimeAgo(); } }
        public FeedDisplayModel(Feed itm){
            this.Created=itm.Created;
            this.Id=itm.Id;
            this.Message=itm.Message;
        }
    }
    public static class DateExtension
    {
        public static string TimeAgo(this DateTime dt)
        {
            return "your implementation of ";
        }
    }
