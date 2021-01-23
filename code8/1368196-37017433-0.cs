    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;
    namespace ConcurrentQueueExperiment
    {
        class Program
        {
            static void Main(string[] args)
            {
                var inputQueue = new ConcurrentQueue<int>();
                var outputQueue = new ConcurrentQueue<int>();
                Enumerable.Range(1,5000).ToList().ForEach(inputQueue.Enqueue);
                while (inputQueue.Any())
                {
                    Task.Factory.StartNew(() =>
                    {
                        int dequeued;
                        if (inputQueue.TryDequeue(out dequeued))
                        {
                            outputQueue.Enqueue(dequeued);
                        }
                    });
                }
                int output = 0;
                var previous = 0;
                while (outputQueue.TryDequeue(out output))
                {
                    if(output!=previous+1)
                        Console.WriteLine("Out of sequence: {0}, {1}", previous, output);
                    previous = output;
                }
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
        }
    }
