    private async Task<CustomHttpResponse> ExecuteGetAsync(CustomHttpRequest inRequest)
    {
        CustomHttpResponse result = null; // Put initial result here.
        var handle = new AutoResetEvent(false);
        NSUrlConnection
            .SendAsynchronousRequest(
                (NSUrlRequest)request,
                NSOperationQueue.MainQueue,
                delegate(NSUrlResponse inResponse, NSData inData, NSError inError)
                {
                    // Return the response somehow
                    result = // make your result
                    handle.Set();
                });
                
        handle.WaitOne(10000) // Wait up to 10 seconds for result
        return result;
    }
