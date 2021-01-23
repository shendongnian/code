    public class CustomHttpActionSelector : IHttpActionSelector
    {
        public HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var isPostSupported = false;
            //logic to determine if you support the method or not
            if (!isPostSupported)
            {
                //set any StatusCode and message here
                var response = controllerContext.Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, "Overriding 405 here.");
                throw new HttpResponseException(response);
            }
        }
        ...
    }
    //add it to your HttpConfiguration (WebApiConfig.cs)
    config.Services.Add(typeof(IHttpActionSelector), new CustomHttpActionSelector());
