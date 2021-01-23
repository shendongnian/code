    private Task<string> ActionToProcessNewValue(string s)
    {
        Func<string> work = () => Label1.Content;
        if(Label1.Dispatcher.CheckAccess())
        {
            return Task.FromResult(work());
        }
        else
        {
            return Label1.Dispatcher.InvokeAsync(work, DispatcherPriority.Send).Task;
        }
    }
