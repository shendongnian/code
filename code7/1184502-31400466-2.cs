    public class MvcApplication : HttpApplication
    {
        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();
    
                var routedata= new RouteData();
                routedata.DataTokens["area"] = "ErrorArea"; // In case controller is in another area
                routedata.Values["controller"] = "Errors";
                routedata.Values["action"] = "NotFound";
    
                IController c = new ErrorsController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), routedata));
            }
        }
    }
