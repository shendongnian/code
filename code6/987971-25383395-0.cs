     private void ExecuteTestCommand()
            {
               // throw new Exception();
    
                Task.Factory.StartNew(() =>
                    {
    
                    }).ContinueWith(t =>
                    {
                         if (t.Exception != null)
                       {
                           App.Current.Dispatcher.Invoke(new Action(() =>
                           {
                               throw t.Exception;
                           }));
                           return;
                       }
    
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            }
     
