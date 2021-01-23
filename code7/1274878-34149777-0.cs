        private BackgroundWorker bwLoading = new BackgroundWorker();
        
        private void Form_Load(object sender, EventArgs e)
        {
             bwLoading.WorkerSupportsCancellation = true;
             bwLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(bwLoading_DoWork);
             bwLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bwLoading_RunWorkerCompleted);
        }
        private void bwLoading_DoWork(object sender, DoWorkEventArgs e)
        {
              StartLoading() //Some Method which performing I want to stop at any time
        }
        private void bwLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                //Do if stopped.
            }
            else{ //Load success }
        }
    
        private void start_Click(object sender, EventArgs e)
        {
            bwLoading.RunWorkerAsync();
        }
    
        private void stop_Click(object sender, EventArgs e)
        {
            //Stop performing Method from start_Click
            if (bwLoading.IsBusy)
            {
                // Notify the worker thread that a cancel has been requested.
                // The cancel will not actually happen until the thread in the
                // DoWork checks the bwLoading.CancellationPending flag. 
                bwLoading.CancelAsync();
            }
        }
