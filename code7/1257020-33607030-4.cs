        public static async Task<HttpResponseMessage> PostWithRetryAsync(this HttpClient httpClient, Uri uri, HttpContent content, int maxAttempts, Action<int> logRetry)
    {
        if (maxAttempts < 1)
            throw new ArgumentOutOfRangeException(nameof(maxAttempts), "Max number of attempts cannot be less than 1.");
    
        var attempt = 1;
        while (attempt <= maxAttempts)
        {
            if (attempt > 1)
                logRetry(attempt);
    
            try
            {
                var response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (HttpRequestException)
            {
                ++attempt;
                if (attempt > maxAttempts)
                    throw;               
            }
        }
        return something; // HERE YOU NEED TO RETURN SOMETHING
    }
