        while (true)
        {
            Thread.Sleep(100);
            string item = null;
            lock (sharedQueue)
            {
                while (sharedQueue.Count == 0)
                    Monitor.Wait(sharedQueue);
                
                if(sharedQueue.TryDequeue(out item)) //succes!
                   ...
                else                                 //something went wrong
                   ...
            }
            Console.WriteLine("Consuming item: {0}", item);
        }
