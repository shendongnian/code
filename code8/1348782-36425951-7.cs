    public class HttpHandler : IHttpHandler {
        IHttpClient _client;
    
        public HttpHandler(IHttpClient client){
            this._client = client;
        }
    
        public IHttpClient client {
            get{
                return _client;
            }
        }
    }
