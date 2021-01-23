    public async Task<List<ObjectToReturn>> GetDataFromAsmxService(GetReportDataRequest somedata)
    {
        var tcs = new TaskCompletionSource<GetReportDataResponse>();
        _asmxService.GetReportDataCompleted += GetReportDataCallBack;
        _asmxService.GetReportDataAsync(somedata, tcs); //we pass tcs in so it can be used from the callback.
        GetReportDataResponse res;
        try
        {
            res = await tcs.Task;
        }
        finally
        {
            //unsubscribe from the handler when done so we don't get a leak.
            _asmxService.GetReportDataCompleted -= GetReportDataCallBack;
        }
            
        var result = process(res);
        return result;
    }
    private void GetReportDataCallBack(object sender, GetReportDataCompletedEventArgs e)
    {
        var tcs = (TaskCompletionSource<GetReportDataResponse>)e.UserState;
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
    }
