    static void Main(string[] args)
            {
                int maxConcurrency = 5;
                List<string> messages =  Enumerable.Range(1, 15).Select(e => e.ToString()).ToList();
    
                using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
                {
                    List<Task> tasks = new List<Task>();
                    foreach (var msg in messages)
                    {
                        concurrencySemaphore.Wait();
    
                        var t = Task.Factory.StartNew(() =>
                        {
    
                            try
                            {
                                Process(msg);
                            }
                            finally
                            {
                                concurrencySemaphore.Release();
                            }
                        });
    
                        tasks.Add(t);
                    }
    
                   // Task.WaitAll(tasks.ToArray());
                }
                Console.WriteLine("Exited using block");
    
                Console.ReadKey();
            }
           
            private static void Process(string msg)
            {            
                Thread.Sleep(2000);
                Console.WriteLine(msg);
    
            }
        }
