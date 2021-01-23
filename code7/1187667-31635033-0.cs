    public class AsyncRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new AsyncHttpHandler();
        }
    }
    
    public class AsyncHttpHandler : HttpTaskAsyncHandler{
        public override async Task ProcessRequestAsync(HttpContext context)
        {        
        }
    }
