    public static class HttpActionResultExtensions {
        public static IHttpActionResult StatusCodeWithContent<T>(this ApiController @this, HttpStatusCode statusCode, T content) {
            return new NegotiatedContentResult<T>(statusCode, content, @this);
        }
    }
