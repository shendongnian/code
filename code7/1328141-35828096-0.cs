    public abstract class BaseAPIController : ApiController {
    
        protected virtual HttpResponseMessage NegotiatedContent<T>(HttpStatusCode statusCode, T content) {
            var type = typeof(T);
            var request = this.Request;
            var formatters = this.Configuration.Formatters;
            var negotiator = this.Configuration.Services.GetContentNegotiator();
            var result = negotiator.Negotiate(type, request, formatters );
            if (result == null) {
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                throw new HttpResponseException(response));
            }
            return new HttpResponseMessage() {
                StatusCode = statusCode,
                Content = new ObjectContent<T>(
                    content,		            // What we are serializing 
                    result.Formatter,           // The media formatter
                    result.MediaType.MediaType  // The MIME type
                )
            };
        }    
    }
