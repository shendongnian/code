    public void Method()
            {
                Console.WriteLine("Hello");
                backgroundWorker1.ReportProgress(30);
                Console.WriteLine("World");
                backgroundWorker1.ReportProgress(60);
                //Do more work here....
                backgroundWorker1.ReportProgress(100);
    
            }
     private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar1.Value = e.ProgressPercentage;
            }
