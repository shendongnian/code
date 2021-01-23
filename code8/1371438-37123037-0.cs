    public async Task<List<ObjectToReturn>> GetDataFromAsmxServiceAsync(object somedata)
    {
        var tcs = new TaskCompletionSource<ResultData>();
        _asmxService.GetReportDataCompleted += (sender, args) =>
        {
            if (args.Cancelled)
            {
                tcs.TrySetCanceled();
            }
            else if (args.Errors != null)
            {
                tcs.TrySetException(args.Errors);
            }
            else
            {
                tcs.TrySetResult(args.Result);
            }
        };
        _asmxService.GetReportDataAsync(somedata);
        var res = await tcs.Task;
        var result = process(res);
        return result;
    }
