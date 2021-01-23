    private async Task<string> ActionToProcessNewValue(string s)
    {
        //I like to put the work in a delegate so you don't need to type 
        // the same code for both if checks
        Action work = () => Label1.Content = s;
        if(Label1.Dispatcher.CheckAccess())
        {
            work();
        }
        else
        {
            var operation = Label1.Dispatcher.InvokeAsync(work, DispatcherPriority.Send);
            //We likely don't need .ConfigureAwait(false) because we just proved
            // we are not on the UI thread in the if check.
            await operation.Task.ConfigureAwait(false);
        }
        
        return string.Format("test2{0}", s);
    }
