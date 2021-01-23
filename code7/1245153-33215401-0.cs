    Dispatcher dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
    if (dispatcher != null) // already on UI thread, no dispatching needed
    {
           if (handler != null)
           {
               handler(this, new PropertyChangedEventArgs(name));
           }
    }
    else
    {
       Application.Current.Dispatcher.Invoke(new Action(() =>
       {
           if (handler != null)
           {
               handler(this, new PropertyChangedEventArgs(name));
           }
       }));
    }
