    /// <summary>
    /// A System.Net.Http message handler that delegates out to Windows.Web.Http.HttpClient.
    /// </summary>
    public class WindowsHttpMessageHandler : HttpMessageHandler
    {
        private const string UserAgentHeaderName = "User-Agent";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient();
            Windows.Web.Http.HttpRequestMessage webRequest = new Windows.Web.Http.HttpRequestMessage
            {
                Method = ConvertMethod(request.Method),
                RequestUri = request.RequestUri,
                Content = await ConvertRequestContentAsync(request.Content).ConfigureAwait(false),
            };
            CopyHeaders(request.Headers, webRequest.Headers);
            Windows.Web.Http.HttpResponseMessage webResponse = await client.SendRequestAsync(webRequest)
                .AsTask(cancellationToken)
                .ConfigureAwait(false);
            HttpResponseMessage response = new HttpResponseMessage
            {
                StatusCode = ConvertStatusCode(webResponse.StatusCode),
                ReasonPhrase = webResponse.ReasonPhrase,
                Content = await ConvertResponseContentAsync(webResponse.Content).ConfigureAwait(false),
                RequestMessage = request,
            };
            CopyHeaders(webResponse.Headers, response.Headers);
            return response;
        }
        private static void CopyHeaders(HttpRequestHeaders input, Windows.Web.Http.Headers.HttpRequestHeaderCollection output)
        {
            foreach (var header in input)
            {
                output.Add(header.Key, GetHeaderValue(header.Key, header.Value));
            }
        }
        private static void CopyHeaders(HttpContentHeaders input, Windows.Web.Http.Headers.HttpContentHeaderCollection output)
        {
            foreach (var header in input)
            {
                output.Add(header.Key, GetHeaderValue(header.Key, header.Value));
            }
        }
        private static void CopyHeaders(Windows.Web.Http.Headers.HttpContentHeaderCollection input, HttpContentHeaders output)
        {
            foreach (var header in input)
            {
                if (!string.Equals(header.Key, "Expires", StringComparison.OrdinalIgnoreCase) || header.Value != "-1")
                {
                    output.Add(header.Key, header.Value);
                }
            }
        }
        private static void CopyHeaders(Windows.Web.Http.Headers.HttpResponseHeaderCollection input, HttpResponseHeaders output)
        {
            foreach (var header in input)
            {
                output.Add(header.Key, header.Value);
            }
        }
        private static string GetHeaderValue(string name, IEnumerable<string> value)
        {
            return string.Join(string.Equals(name, UserAgentHeaderName, StringComparison.OrdinalIgnoreCase) ? " " : ",", value);
        }
        private static Windows.Web.Http.HttpMethod ConvertMethod(HttpMethod method)
        {
            return new Windows.Web.Http.HttpMethod(method.ToString());
        }
        private static async Task<Windows.Web.Http.IHttpContent> ConvertRequestContentAsync(HttpContent content)
        {
            if (content == null)
            {
                return null;
            }
            Stream contentStream = await content.ReadAsStreamAsync().ConfigureAwait(false);
            var result = new Windows.Web.Http.HttpStreamContent(contentStream.AsInputStream());
            CopyHeaders(content.Headers, result.Headers);
            return result;
        }
        private static async Task<HttpContent> ConvertResponseContentAsync(Windows.Web.Http.IHttpContent content)
        {
            var responseStream = await content.ReadAsInputStreamAsync();
            var result = new StreamContent(responseStream.AsStreamForRead());
            CopyHeaders(content.Headers, result.Headers);
            return result;
        }
        private static HttpStatusCode ConvertStatusCode(Windows.Web.Http.HttpStatusCode statusCode)
        {
            return (HttpStatusCode)(int)statusCode;
        }
    }
