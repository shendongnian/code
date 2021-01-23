    public class MaxContentLengthAttribute : AuthorizationFilterAttribute
    {
        private readonly long _maxContentType;
        public MaxContentLengthAttribute(long maxContentType)
        {
            _maxContentType = maxContentType;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var contentLength = actionContext.Request.Content.Headers.ContentLength;
            if (contentLength.HasValue && contentLength.Value > _maxContentType)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.RequestEntityTooLarge);
            }
        }
    }
