    private Task<CustomHttpResponse> ExecuteGetAsync(CustomHttpRequest inRequest)
    {
        var tcs = new TaskCompletionSource<CustomHttpResponse>();
        NSUrlConnection
            .SendAsynchronousRequest(
                (NSUrlRequest)request, //shouldn't this be inRequest?
                NSOperationQueue.MainQueue,
                delegate(NSUrlResponse inResponse, NSData inData, NSError inError)
                {
                    bool error = ... //determine if we have an error
                    if(error)
                        tcs.SetException(new Exception(".. error message here ..")); //if we have an error, use the SetException method to set the exception for the Task
                    else
                    {
                        CustomHttpResponse result = ... // if we don't have an error, get result
                        tcs.SetResult(result); //if we don't have an error, set the result
                    }
                });
        return tcs.Task;
    }
