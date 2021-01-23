    private bool isBusy = false;
    public bool IsBusy
    {
        get
        {
            return isBusy;
        }
        set
        {
            isBusy = value;
            RaisePropertyChanged("IsBusy");
        }
    }
    private async void StartTaskHandler()
    {
        cancellationTokenSource = new CancellationTokenSource();
        IsBusy = true;
        someTask = Task.Run(new Action(() =>
        {
            // Simulate some work
            cancellationTokenSource.Token.WaitHandle.WaitOne(10000);
        }), cancellationTokenSource.Token);
        await someTask;
        IsBusy = false;
    }
