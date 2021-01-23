    public class HttpHelper : IHttpHelper
    {
        private ILogHelper _logHelper;
        public HttpHelper(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }
        public virtual async Task<HttpResponseMessage> GetAsync(string uri, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        client.DefaultRequestHeaders.Add(h.Key, h.Value);
                    }
                }
                response = await client.GetAsync(uri);
            }
            return response;
        }
        public async Task<T> GetAsync<T>(string uri, Dictionary<string, string> headers = null)
        {
            ...
            rawResponse = await GetAsync(uri, headers);
            ...
        }
       
    }
