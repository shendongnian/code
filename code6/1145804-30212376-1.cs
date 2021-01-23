    private BackgroundWorker _worker;
    private void MyView_Loaded(object sender, RoutedEventArgs e)
    {
        _worker = new BackgroundWorker();
        _worker.WorkerSupportsCancellation = true;
        _worker.DoWork += (o, ea) =>
        {
            while (true)
            {
                if (_actionCompletedEvent.WaitOne(0))
                {
                    if (_worker.CancellationPending)
                    {
                        ea.Cancel = true;
                        return;
                    }
                    // Issue
                    Dispatcher.Invoke(new Action(() =>
                    {
                        Close();
                    }));
                    Thread.Sleep(100);
                }
                while (!_actionReports.IsEmpty)
                {
                    // Do some stuff
                }
            }
        };
    }
    protected override void OnClosing(CancelEventArgs e)
    {
        _worker.CancelAsync();
    }
