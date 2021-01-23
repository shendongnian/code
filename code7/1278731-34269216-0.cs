    public static class Program
    {
        public static void Main()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.Disposed += BackgroundWorker_Disposed;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }
        private static void BackgroundWorker_Disposed(object sender, EventArgs e)
        {
            // Cleanup after yourself.
        }
        private static void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do your things in background.
        }
        private static void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Notify progress.
        }
        private static void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background task is complete ("successfully" is NOT implied).
        }
    }
