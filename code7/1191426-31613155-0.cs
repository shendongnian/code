        static ConcurrentQueue<string> filenames = new ConcurrentQueue<string>();
        static void QueueHandler()
        {
            bool run = true;
            AppDomain.CurrentDomain.DomainUnload += (s, e) =>
            {
                run = false;
                filenames.Enqueue("stop");
            };
            while(run)
            {
                string filename;
                if (filenames.TryDequeue(out filename) && run)
                {
                    var proc = new Process();
                    proc.StartInfo.FileName = filename;
                    proc.Start();
                    proc.WaitForExit(); // this blocks until the process ends....
                }
            }
        }
