    public async static Task<string> ProcessAsync(MyService service, int parameter)
    {
        var tcs = new TaskCompletionSource<string>();
        
        EventHandler<CustomEventArg> callback = 
            (s, e) => tcs.SetResult(e.Result);
            
        try
        {
            contacts.Completed  += callback;
     
            contacts.RunAsync(parameter);
     
            return await tcs.Task;
        }
        finally
        {
            contacts.Completed  -= callback;
        }
    }
