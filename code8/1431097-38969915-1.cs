    public class ExampleController : Controller
    {
        [Route("r/{subreddit}/{topic}")]
        public ActionResult Topic(string subreddit, string topic)
        {
             //Logic goes here
        } 
    }
