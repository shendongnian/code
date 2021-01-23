    private const int NumberOfRetries = 3;
    private const int DelayOnRetry = 1000;
    public static HttpResponseMessage GetFromUrl(string url) {
        for (int i=1; i <= NumberOfRetries; ++i) {
            try {
                // Also consider to make this method async and await this
                return new HttpClient().GetAsync(url).Result;
            }
            catch (Exception e) {
                // Do better than this! Catch what you want to handle,
                // not all exceptions worth a retry. Documentation and many
                // tests will help you to narrow a limited subset of
                // exceptions and error codes.
                if (i == NumberOfRetries ) // Last retry, throw exception and exit
                    throw;
    
                // Many network related errors will recover "automatically"
                // after some time, exact delay is pretty arbitrary and
                // should be determined with some tests. 1 second is pretty
                // "good" for local I/O operations but network issues may
                // need longer delays.
                Thread.Sleep(DelayOnRetry);
            }
        }
    }
