    private void StartTaskHandler()
    {
       IsBusy=true;
       someTask = Task.Run(new Action(() =>
       {
           // Simulate some work
           cancellationTokenSource.Token.WaitHandle.WaitOne(10000);
         }), cancellationTokenSource.Token);
         someTask.ContinueWith((task) => RaisePropertyChanged("TaskRunning"));
       IsBusy=false;
    }
