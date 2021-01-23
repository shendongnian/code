      static void Main()
        {
            // setup some form state
            Form form = new Form();
          
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
           
            // start the worker when the form loads
            form.Load += delegate
            {
                worker.RunWorkerAsync();
            };
            worker.DoWork += delegate
            {
                // this code happens on a background thread, so doesn't
                // block the UI while running - but shouldn't talk
                // directly to any controls
                for (int i = 0; i < 500; i++)
                {
                    worker.ReportProgress(0, "Item " + i);
                    Thread.Sleep(150);
                }
            };
            worker.ProgressChanged += delegate(object sender,
               ProgressChangedEventArgs args)
            {
                SendKeys.Send("{Enter}");
            };
            Application.Run(form);
        }
