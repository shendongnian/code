    public class HomeController : Controller
    {
        public string Index(string search)
        {
            Thread.Sleep(5000);
            return "Hello " + search;
        }
    }
