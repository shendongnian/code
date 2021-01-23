            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += BwOnDoWork;
            bw.ProgressChanged += BwOnProgressChanged;
            bw.RunWorkerCompleted += BwOnRunWorkerCompleted;
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            //This line here is what starts the asynchronous work
            bw.RunWorkerAsync();
          
       
        private void BwOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
             //Do whatever you want to do when it is done with its asynchronous task
             //for example
             Label.Content = "Yay, Were done doing whatever it was that we were doing!!!!"
        }
        private void BwOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Here is where we can send progress reports to the UI, like updating a loading bar
            MyProgressBar.EditValue = e.ProgressPercentage;
           
        }
        private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            //This is where we will put anything we want to be ran asynchronously
            this.RunWhateverMethodWillDoABunchOfStuff()
        }
