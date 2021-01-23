    private async Task<string> ActionToProcessNewValue(string s)
    {
        //I like to put the work in a delegate so you don't need to type the same code for both if checks
        Action work = () => Label1.Content = s;
        if(Label1.Dispatcher.CheckAccess())
        {
            work();
        }
        else
        {
            await Label1.Dispatcher.InvokeAsync(work, DispatcherPriority.Send).Task;
        }
        
        return string.Format("test2{0}", s);
    }
