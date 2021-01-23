    /// <summary>
    /// HTTP Client adaptor wraps a <see cref="System.Net.Http.HttpClient"/> 
    /// that contains a reference to <see cref="ConfigurableMessageHandler"/>
    /// </summary>
    public sealed class HttpClientAdaptor : IHttpClient {
        HttpClient httpClient;
        public HttpClientAdaptor(IHttpClientFactory httpClientFactory) {
            httpClient = httpClientFactory.CreateHttpClient(**Custom configurations**);
        }
