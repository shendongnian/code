    public class HomeController : Controller
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
            return this.RenderView("AddComplete", client);
        }
    }
    public static class ControllerExtensions
    {
        public static ViewResult RenderView(this Controller controller, string view, Guid clientId)
        {
            string viewName = GetViewForClient(view, clientId);
            return controller.View(view);
        }
        public static string GetViewForClient(string view, Guid clientId)
        {
            // todo: logic to return view...
        }
    }
