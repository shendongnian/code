    public class HomeController : Controller
    {
        public PartialViewResult SomeAction()
        {
            //you can access the session anywhere
            var s = Session["MyProperty"] as YourTypeHere;
        }
    }
