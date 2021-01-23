    public static class BackgroundWorkerExt
    {
        public static void RunWorkerAsync(this BackgroundWorker worker, Action action)
        {
            worker.RunWorkerAsync(action);
        }
    }
