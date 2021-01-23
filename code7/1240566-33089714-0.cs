    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsDataContractJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            return client.PostAsJsonAsync(requestUri, value, CancellationToken.None);
        }
        public static Task<HttpResponseMessage> PostAsDataContractJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, new JsonMediaTypeFormatter { UseDataContractJsonSerializer = true }, cancellationToken);
        }
    }
