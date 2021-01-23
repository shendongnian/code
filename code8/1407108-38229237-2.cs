    public async Task Execute()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        var taskCompletionSource = new TaskCompletionSource<object>();
        //Token registrations need to be disposed when done.
        using(_cancellationTokenSource.Token.Register(
            () => taskCompletionSource.TrySetCanceled()))
        {
            DataPreparer dataPreparer = null;
            var task = Task.Run(() =>
            {
                if (QueryTypeIsOu())
                {
                    dataPreparer = SetUpOuDataPreparer(_cancellationTokenSource.Token);
                }
                else if (QueryTypeIsContextComputer())
                {
                    dataPreparer = SetUpComputerDataPreparer(_cancellationTokenSource.Token);
                }
                else if (QueryTypeIsContextDirectReportOrUser())
                {
                    dataPreparer = SetUpDirectReportOrUserDataPreparer(_cancellationTokenSource.Token);
                }
                else if (QueryTypeIsContextGroup())
                {
                    dataPreparer = SetUpGroupDataPreparer(_cancellationTokenSource.Token);
                }
                Data = GetData(dataPreparer, _cancellationTokenSource.Token);
            },
            _cancellationTokenSource.Token);
            await Task.WhenAny(task, taskCompletionSource.Task);
       }
    }
