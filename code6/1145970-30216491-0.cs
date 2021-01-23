    public partial class MainWindow : Window, IDisposable
    {
...
        public void Dispose()
        {
            worker.DoWork -= worker_DoWork;
            worker.ProgressChanged -= worker_ProgressChanged;
            worker.RunWorkerCompleted -= worker_RunWorkerCompleted;
        }
    }
