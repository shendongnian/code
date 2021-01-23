    public static class StatusCodeExtensions
    {
        private static readonly ConcurrentDictionary<HttpStatusCode, bool> IsSuccessStatusCode = new ConcurrentDictionary<HttpStatusCode, bool>();
        public static bool IsSuccess(this HttpStatusCode statusCode) => IsSuccessStatusCode.GetOrAdd(statusCode, c => new HttpResponseMessage(c).IsSuccessStatusCode);
    }
