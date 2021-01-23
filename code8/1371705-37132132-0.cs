            var myPrintServer = new LocalPrintServer();
            var pq = myPrintServer.GetPrintQueue("Printer Name");
            var jobs = pq.GetPrintJobInfoCollection();
            foreach (var job in jobs)
            {
                var done = false;
                while (!done)
                {
                    pq.Refresh();
                    job.Refresh();
                    done = job.IsCompleted || job.IsDeleted || job.IsPrinted;
                }
            }
