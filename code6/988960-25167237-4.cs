            foreach (var workItem in inputQueue.GetConsumingEnumerable())
            {
                Console.WriteLine("Worker {0} is processing item {1}", workerId, workItem);
                Thread.Sleep(100);          // Simulate work.
                outputQueue.Add(workItem);  // Output completed item.
            }
