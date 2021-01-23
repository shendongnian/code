    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> Delete(this HttpClient client, HttpContent content)
        {
            var request = new HttpRequestMessage { Method = "DELETE", Content = content);
            return client.SendAsync(request);
        }
    }
