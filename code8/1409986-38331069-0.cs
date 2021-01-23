    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace Demo
    {
        class Keyword // Dummy test class.
        {
            public string Name;
        }
        class Program
        {
            static void Main()
            {
                // Dummy test data.
                var keywords = Enumerable.Range(1, 100).Select(n => n.ToString()).ToList();
                var result = DoWork(keywords).Result;
                Console.WriteLine("---------------------------------");
                foreach (var item in result)
                    Console.WriteLine(item.Name);
            }
            public static async Task<List<Keyword>> DoWork(List<string> keywords)
            {
                var input = new TransformBlock<string, Keyword>
                (
                    async s => await Work(s),
                    // This is where you specify the max number of threads to use.
                    new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 8 }
                );
                var result = new List<Keyword>();
                var output = new ActionBlock<Keyword>
                (
                    item => result.Add(item),   // Output only 1 item at a time, because 'result.Add()' is not threadsafe.
                    new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 }
                );
                input.LinkTo(output, new DataflowLinkOptions { PropagateCompletion = true });
                foreach (string s in keywords)
                    await input.SendAsync(s);
                input.Complete();
                await output.Completion;
                return result;
            }
            public static async Task<Keyword> Work(string s) // Stubbed test method.
            {
                Console.WriteLine("Processing " + s);
                int delay;
                lock (rng) { delay = rng.Next(10, 1000); }
                await Task.Delay(delay); // Simulate load.
                Console.WriteLine("Completed " + s);
                return await Task.Run( () => new Keyword { Name = s });
            }
            static Random rng = new Random();
        }
    }
