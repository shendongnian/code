       BackgroundWorker _worker;
       
       public void Form_Load(object sender, EventArgs e) {
           _worker = new BackgroundWorker(); // Should be a field on the form.
           _worker.DoWork += DoWork;
           _worker.RunWorkerCompleted += RunWorkerCompleted;
           lblDisplayStatus.Text = "Detecting Disk Drives...";
           _worker.RunWorkerAsync();
       }
    
       private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)   {
         lblDisplayStatus.Text = "Done...";       
        }
    
       private void DoWork(object sender, DoWorkEventArgs e) {
           getAndDisplayData();
       }
   
