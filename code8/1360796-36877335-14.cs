    public bool CloseWindow()
            {
                winClose = () =>
                {
                    mw.Dispatcher.Invoke(() =>
                       {
                           mw.Close();
                           mw.Dispose();
                       });
                };
                cleanProc = () =>
                {
                    mw.Dispatcher.Invoke(() =>
                    {
                        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                        GC.WaitForPendingFinalizers();
                        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                    });
                };
                Task.Run(() =>
               {
                   winClose.Invoke();
               }).ContinueWith(x =>
    
                   {
                       cleanProc.Invoke();
                   });
                
                return true;
            }
