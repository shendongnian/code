    private bool _someExternalFlag;
    private void Test(BlockingCollection items)
    {
        _someExternalFlag = false;
        using (var worker = new BackgroundWorker())
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += delegate
            {
                var index = 0;
                foreach (var item in items)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }
                    index++;
                    // ... process your item here or by passing it to the main thread
                    worker.ReportProgress(index, item);
                }
            };
            worker.ProgressChanged += delegate(object sender, ProgressChangedEventArgs e)
            {
                if (_someExternalFlag)
                {
                    worker.CancelAsync();
                }
                else
                {
                    var item = e.UserState as BlockingItem;
                    // use item if you need it
                }
            };
            worker.RunWorkerAsync();
        }
    }
