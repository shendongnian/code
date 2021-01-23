    public class CustomHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //get route values and process them
            var routeValues = (IHttpRouteData[]) HttpContext.Current.Request.RequestContext.RouteData.Values["MS_SubRoutes"];
            //let other handlers process the request
            return await base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    //once response is ready, do something with it                                        
                    return task.Result;
                }, cancellationToken);
        }
    }
