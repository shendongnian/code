    public class HomeController : Controller {
        public IHtmlString TyneMice()
        {
           return new MvcHtmlString(System.IO.File.ReadAllText("filename"));
        }
    }
