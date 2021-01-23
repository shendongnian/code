    public static Task<string> ProcessAsync(MyService service, int parameter)
    {
        var tcs = new TaskCompletionSource<string>();
        EventHandler<CustomEventArg> callback = null;
        callback = (sender, e) => 
        {
            service.Completed -= callback;
            tcs.SetResult(e.Result); 
        };
        service.Completed += callback;
        service.RunAsync(parameter);
        return tcs.Task;
    }
