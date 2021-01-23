            for (int i = 0; i < 100; ++i)
            {
                Console.WriteLine("Queueing work item {0}", i);
                inputQueue.Add(i);
                Thread.Sleep(50);
            }
