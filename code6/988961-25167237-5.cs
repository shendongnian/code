            foreach (var workItem in outputQueue.GetConsumingEnumerable())
            {
                Console.WriteLine("Consumer is using item {0}", workItem);
                Thread.Sleep(25);
            }
