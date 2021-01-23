    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            JsConfig.DateHandler = DateHandler.ISO8601;
            JsConfig.EmitCamelCaseNames = true;
            //...
        }
    }
