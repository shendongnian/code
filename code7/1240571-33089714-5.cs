    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, JsonSerializerSettings settings)
        {
            return client.PostAsJsonAsync(requestUri, value, settings, CancellationToken.None);
        }
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, JsonSerializerSettings settings, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, new JsonMediaTypeFormatter { SerializerSettings = settings }, cancellationToken);
        }
    }
