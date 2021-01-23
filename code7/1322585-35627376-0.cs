    public class Class1TestController
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var feeds = db.Feeds.ToList();
                return View(feeds);
            }
        }
    }
    class Feed
    {
        public DateTime Created { get; }
        public int Id { get; }
        public string Message { get; }
    }
    class FeedDisplayModel : Feed
    {
        public string Ago { get { return Created.TimeAgo(); } }
    }
    public static class DateExtension
    {
        public static string TimeAgo(this DateTime dt)
        {
            return "your implementation of ";
        }
    }
