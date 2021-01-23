    public class MyController : ApiController
    {
        public string GetName(string id)
        {
            return id;
        }
        public string GetNameById(string id)
        {
            return id;
        }
    }
    GlobalConfiguration.Configuration.Routes.MapHttpRoute
            ("default","api/{controller}/{action}/{id}",new { id = RouteParameter.Optional });
