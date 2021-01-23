    private const int NumberOfRetries = 3;
    private const int DelayOnRetry = 1000;
    public static HttpResponseMessage GetFromUrl(string url) {
        for (int i=1; i <= NumberOfRetries; ++i) {
            try {
                // Also consider to make this method async and await this
                return new HttpClient().GetAsync(url).Result;
            }
            catch (Exception e) {
                // DO BETTER THAN THIS! Catch what you want to handle,
                // not all exceptions worth a retry. Documentation and many
                // tests will help you to narrow a limited subset of
                // exceptions and error codes.
                // Last one, (re)throw exception and exit
                if (i == NumberOfRetries)
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
