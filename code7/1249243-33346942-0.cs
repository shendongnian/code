    public class HomeController : Controller {
        public string TyneMice()
        {
           return System.IO.File.ReadAllText("filename");
        }
    }
