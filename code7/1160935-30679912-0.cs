    void method(){
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
            worker.WorkerSupportsCancellation = true;
            if(!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
    }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //do whatever needs to be done on the other thread here.
            object argument = e.Argument; //if passed argument in RunWorkerAsync().
            object result = new object();
            e.Result = result;
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //you can update a progress bar in here
            int progress = e.ProgressPercentage;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //when done
        }
        void CancelTheTask()
        {
            if (!worker.IsBusy)
            {
                //make worker global first, but then
                worker.CancelAsync();
            }
        }
