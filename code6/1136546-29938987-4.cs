    private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
    private void BrowserLoaded(object sender, NavigationEventArgs navigationEventArgs)
    {                   
        tcs.TrySetResult(true);
    }
    
    private async Task<object> InvokeScript(string invoke, object[] parameters = null)
    {
        var timeoutTask = Task.Delay(TimeSpan.FromSeconds(10));
        if (timeoutTask == await Task.WhenAny(tcs.Task, timeoutTask))
        {
            // You've timed out;
        }
        return Task.Run(() =>
        {
             parameters == null ? browser.InvokeScript(invoke)
                                : browser.InvokeScript(invoke, parameters)
        });
    }
