    public class CustomRouteHandler : MvcRouteHandler
    {
      protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
      {
        var acceptValue = requestContext.HttpContext.Request.Headers["Accept"];
        if( /* do something with the accept value */)
        {
            // Set the new route value in the
            // requestContext.RouteData.Values dictionary
            // e.g. requestContext.RouteData.Values["action"] = "Customer";
        }
        return base.GetHttpHandler(requestContext);
      }
    }
