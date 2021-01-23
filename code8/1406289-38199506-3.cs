    public abstract class ControllerTestBase
    {
        protected ControllerTestBase()
        {
            BaseUrl = "http://localhost/api/";
        }
        public string BaseUrl { get; set; }
        public static HttpServer CreateHttpServer()
        {
            var httpConfiguration = WebApiConfig.Register();
            return new HttpServer(httpConfiguration);
        }
        
        public static HttpMessageInvoker CreateHttpInvoker(HttpServer httpServer)
        {
            return new HttpMessageInvoker(httpServer);
        }
        public HttpRequestMessage CreateHttpRequest(HttpMethod httpMethod, string url)
        {
            return new HttpRequestMessage(httpMethod, url);
        }
    }
