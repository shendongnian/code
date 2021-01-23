    public class MyPresenter {
        public MyPresenter(IServiceAgent services) {...}
    }
    public class DefaultServiceAgent : IServiceAgent {
        IHttpClient httpClient;
        public DefaultServiceAgent (IHttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public async Task<SomeResultObject>(string myParameter) {
              var url = "http://localhost/my_web_api_endpoint?q=" + myParameter;
              var result = await httpClient.GetAsync<SomeResultObject>(url);
              return result;
        }
    }
