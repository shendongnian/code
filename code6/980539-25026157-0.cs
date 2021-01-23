        public void RunCommands(int runid, int batchCount)
        {            
            Task[] tasks = new Task[batchCount];
            maxBatch = batchCount;
            for (int i = 0; i < batchCount; i++ )
            {
                if (i != batchCount && i >= 0)
                {
                    tasks[i] = Task.Factory.StartNew(() => DoWork(runid, i));
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Overflow..");
                }
            }
            Task.WaitAll(tasks);
        }
