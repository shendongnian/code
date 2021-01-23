    public class MyPresenter {
        public MyPresenter(IServiceAgent services) {...}
    }
    public class MyDefaultServiceAgent : IServiceAgent {
        IHttpClient httpClient;
        public MyDefaultServiceAgent (IHttpClient httpClient) {
            this.httpClient = httpClient;
        }
        public async Task<SomeResultObject> GetSomething(string myParameter) {
              var url = "http://localhost/my_web_api_endpoint?q=" + myParameter;
              var result = await httpClient.GetAsync<SomeResultObject>(url);
              return result;
        }
    }
    public class MyDefaultHttpClient : IHttpClient {
        HttpClient httpClient; //The real thing
        public MyDefaultHttpClient() {
            httpClient = createHttpClient();
        }
        /// <summary>
        ///  Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">The Uri the request is sent to</param>
        /// <returns></returns>
        public System.Threading.Tasks.Task<T> GetAsync<T>(string uri) where T : class {
            return GetAsync<T>(new Uri(uri));
        }
        /// <summary>
        ///  Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Response type</typeparam>
        /// <param name="uri">The Uri the request is sent to</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<T> GetAsync<T>(Uri uri) where T : class {
            var result = default(T);
            //Try to get content as T
            try {
                //send request and get the response
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                //if there is content in response to deserialize
                if (response.Content.Headers.ContentLength.GetValueOrDefault() > 0) {
                    //get the content
                    string responseBodyAsText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    //desrialize it
                    result = deserializeJsonToObject<T>(responseBodyAsText);
                }
            } catch (Exception ex) {
                Log.Error(ex);
            }
            return result;
        }
        private static T deserializeJsonToObject<T>(string json) {
            var result = JsonSerializer.Deserialize<T>(json);
            return result;
        }
    }
