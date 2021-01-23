    public class DoSomething
            {
    
                public void Do()
                {
                    var worker = new BackgroundWorker();
                    worker.WorkerReportsProgress = true;
                    worker.DoWork += WorkerOnDoWork;
                    worker.ProgressChanged += WorkerOnProgressChanged;
                    worker.RunWorkerAsync("Paremeter to pass to the BackgroundWorker");
                }
    
                private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
                {
                    var temp = StatusChanged;
                    if (temp != null)
                        temp((string) e.UserState);
                }
    
                private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
                {
                    var worker = (BackgroundWorker) sender;
                    // If you want to get the passed argument you can call
                    var parameter = e.Argument;
    
                    for (int i = 0; i < 100000; i++)
                    {
                        // do your background-stuff here
                        // ...
                        // Notify the UI
                        worker.ReportProgress(0, "STATUS-OBJECT");
                    }
                }
    
                public delegate void OnStatusChanged(string status);
    
                public event OnStatusChanged StatusChanged;
            }
