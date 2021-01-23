    public Task<long> GetPointAsyncTask(this PointWebService webService, int nationalCode)
    {
        TaskCompletionSource<long> tcs = new TaskCompletionSource<long>();
        webService.GetPointAsyncCompleted += (s, e) =>
        {
            if (e.Cancelled)
            {
                tcs.TrySetCanceled();
            }
            else if (e.Error != null)
            {
                tcs.TrySetException(e.Error);
            }
            else
            {
                tcs.TrySetResult(e.Result);
            }
        };
        webService.GetPointAsync(nationalCode);
        return tcs.Task;
    }
    ...
    using (PointWebService service = new PointWebService())
    {
        long point = await service.GetPointAsyncTask(123).ConfigureAwait(false);
    }
