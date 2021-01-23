    public static Task<TResponse> ExecuteAsync2<TResponse>(Request request) where TResponse : Response {
        var tcs = new TaskCompletionSource<TResponse>();
        proxy.ExecuteRequestAsync(request).ContinueWith(t => {
            if (t.IsFaulted)
                tcs.TrySetException(t.Exception.InnerExceptions);
            else if (t.IsCanceled)
                tcs.TrySetCanceled();
            else
                tcs.TrySetResult((TResponse) t.Result);
            }, TaskContinuationOptions.ExecuteSynchronously);
        return tcs.Task;
    }
