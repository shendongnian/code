        worker.WorkerReportsProgress = true;
        worker.ProgressChanged += ProgressChanged;
        while (!worker.IsBusy)
        {
           worker.RunWorkerAsync();
        }
