    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            JsConfig.Init(new Config {
                DateHandler = DateHandler.ISO8601,
                TextCase = TextCase.CamelCase
            });
            //...
        }
    }
