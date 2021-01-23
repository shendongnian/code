    public static async Task<HttpResponseMessage> GetFromUrl(string url) {
        using (var client = new HttpClient()) {
            for (int i=1; i <= NumberOfRetries; ++i) {
                try {
                        return await client.GetAsync(url); 
                }
                catch (Exception e) when (i < NumberOfRetries) {
                    await Task.Delay(DelayOnRetry);
                }
            }
        }
    }
