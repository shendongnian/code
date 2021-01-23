    private void DoSomethingAsync() {
        /* here we are on the UI thread */
        Dispatcher dispatcher = (Application.Current!=null) ?
             Application.Current.Dispatcher :
             Dispatcher.CurrentDispatcher;
          
        ProgressBarVisibility = Visibility.Visible;
        Task.Factory.StartNew(() => { 
                 /* here we are on the background thread */ 
                 PerformCDDetection(dispatcher); 
             }).ContinueWith(t => { ProgressBarVisibility = Visibility.Collapsed; });
    }
