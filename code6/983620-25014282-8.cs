    public static HttpResponseMessage GetFromUrl(string url) {
        for (int i=1; i <= NumberOfRetries; ++i) {
            try {
                // Also consider to make this method async and await this
                return new HttpClient().GetAsync(url).Result;
            }
            catch (Exception e) when (i < NumberOfRetries) {
                Thread.Sleep(DelayOnRetry);
            }
        }
    }
