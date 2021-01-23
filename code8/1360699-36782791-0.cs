        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // I guess this is how you are using your logger, right?
            ScreenLogging.SetTarget(this.txtLogging);
            BackgroundWorker worker = new BackgroundWorker();
            // Your classic event to do the background work...
            worker.DoWork += Worker_DoWork;
            // Here you can sender messages to UI.
            worker.ProgressChanged += Worker_ProgressChanged;
            // Don't forget to turn this property to true.
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            Thread.Sleep(3000);
            // ReportProgress sends two values to the ProgressChanged method, for the
            // ProgressChangedEventArgs object. The first one is the percentage of the 
            // work, and the second one can be any object that you need to pass to UI.
            // In a simple example, I am passing my log message and just putting 
            // any random value at progress, since it does not matter here.
            worker.ReportProgress(0, "Test!");
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Here you get your UserState object, wich is my string message passed on 
            // with the ReportProgress method above.
            var message = e.UserState as string;
            // Then you call your log as always. Simple, right?
            ScreenLogging.Write(message, LoggingLevel.Info);
        }
