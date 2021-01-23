        static void Main(string[] args)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork; //here
            worker.ProgressChanged += Worker_ProgressChanged; //and here
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
            Console.ReadLine();
        }
