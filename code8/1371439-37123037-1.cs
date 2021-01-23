    public async Task<List<ObjectToReturn>> GetDataFromAsmxServiceAsync(object somedata)
    {
        var tcs = new TaskCompletionSource<GetReportDataResponse>();
        //I am guessing on the name of GetReportDataCompletedHandler because you did not 
        // show the event's definition in the code from Reference.cs
        var completedHandler = new GetReportDataCompletedHandler((sender, args) =>
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
        });
        _asmxService.GetReportDataCompleted += completedHandler;
        _asmxService.GetReportDataAsync(somedata);
        
        GetReportDataResponse res;
        try
        {
            res = await tcs.Task;
        }
        finally
        {
            //unsubscribe from the handler when done so we don't get a leak.
            _asmxService.GetReportDataCompleted -= completedHandler;
        }
        var result = process(res);
        return result;
    }
