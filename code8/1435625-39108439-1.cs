    private string ActionToProcessNewValue(string s)
    {
        Action work = () => Label1.Content = s;
        if(Label1.Dispatcher.CheckAccess())
        {
            work();
        }
        else
        {
            Label1.Dispatcher.Invoke(work, DispatcherPriority.Send);
        }
        
        return string.Format("test2{0}", s);
    }
