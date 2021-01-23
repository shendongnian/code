    public class HttpHandler : IHttpHandler {
        IHttpClient client;
    
        public HttpHandler(IHttpClient client){
            this.client = client;
        }
    
        public IHttpClient client {
            get{
                return client;
            }
        }
    }
