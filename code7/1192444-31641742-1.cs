    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static BlockingCollection<int> _items = new BlockingCollection<int>(); 
            static void Main(string[] args)
            {
                //Start up 4 threads
                var threads = new Thread[4];
                for (int i = 0; i < threads.Length; i++)
                {
                    var iCopy = i;
                    threads[i] = new Thread(() => ProcessItems(iCopy));
                    threads[i].IsBackground = true;
                    threads[i].Start();
                }
    
                //Give the threads 5 items to process.
                for (int i = 0; i < 5; i++)
                {
                    _items.Add(i);
                }
    
                Console.WriteLine("All items queued, sleeping 2 seconds");
                Thread.Sleep(2000);
    
                //Give the threads 10 more items to process.
                for (int i = 0; i < 10; i++)
                {
                    _items.Add(i);
                }
                _items.CompleteAdding();
                Console.WriteLine("Marked adding complete");
    
                foreach (var t in threads) t.Join();
    
                Console.WriteLine("All threads complete");
                Console.ReadLine();
            }
    
            static void ProcessItems(int i)
            {
                var rnd = new Random(i);
                foreach (var item in _items.GetConsumingEnumerable())
                {
                    Console.WriteLine("Thread {0} Processing item {1}", i, item);
    
                    //Simulate a random amount work
                    Thread.Sleep(rnd.Next(100, 500));
                }
            }
        }
    }
