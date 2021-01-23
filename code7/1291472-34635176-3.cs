    public Task<long> GetPointAsyncTask(this PointWebService webService, int nationalCode)
    {
        TaskCompletionSource<long> tcs = new TaskCompletionSource<long>();
        webService.GetPointAsyncCompleted += (s, e) =>
        {
            if (e.Cancelled)
            {
                tcs.SetCanceled();
            }
            else if (e.Error != null)
            {
                tcs.SetException(e.Error);
            }
            else
            {
                tcs.SetResult(e.Result);
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
