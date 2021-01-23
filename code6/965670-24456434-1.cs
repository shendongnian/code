    public class HomeController : DynamicViewControllerBase
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // set client
            var client = new Client();
            client.Id = Guid.NewGuid();
            client.Name = "Foo";
            // set user
            var user = new User();
            user.Id = Guid.NewGuid();
            user.ClientId = client.Id;
            user.Name = "Foo";
            return RenderView("AddComplete", client);
        }
    }
    public class DynamicViewControllerBase : Controller
    {
        protected ViewResult RenderView(string view, Guid clientId)
        {
            string viewName = GetViewForClient(view, clientId);
            return View(view);
        }
        // Unless you plan to use methods and properties within 
        // the instance of `Controller`, you can leave this as 
        // a static method.
        private static string GetViewForClient(string view, Guid clientId)
        {
            // todo: logic to return view...
        }
    }
