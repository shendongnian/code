    public static Task<string> ProccessAsync(MyService service, int parameter)
    {
        var tcs = new TaskCompletionSource<string>();
        Action<object, CustomEventArg> callback;
        callback = (sender, e) => 
        {
            service.Completed -= callback;
            tcs.SetResult(e.Result); 
        };
        service.Completed += callback;
        service.RunAsync(parameter);
        return tcs.Task;
    }
