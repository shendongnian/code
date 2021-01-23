    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    
    namespace DataflowTest
    {
        class Program
        {
            public const int BATCH_SIZE = 10;
            static void Main(string[] args)
            {
                Console.WriteLine("Application started");
    
                //Create the pipeline of actions
                var transformBlock = new TransformBlock<string, string>(input => TransformString(input), new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 });
                var batchBlock = new BatchBlock<string>(BATCH_SIZE);
                var outputStringsBlock = new ActionBlock<IEnumerable<string>>(strings => OutputStrings(strings), new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 });
    
                Console.WriteLine("Blocks created");
    
                //link the actions
                transformBlock.LinkTo(batchBlock, new DataflowLinkOptions { PropagateCompletion = true });
                batchBlock.LinkTo(outputStringsBlock, new DataflowLinkOptions { PropagateCompletion = true });
                batchBlock.Completion.ContinueWith(obj => outputStringsBlock.Complete());
    
                Console.WriteLine("Blocks linked");
    
                var testInputs = new List<string>
                {
                    "Kyle",
                    "Stephen",
                    "Jon",
                    "Conor",
                    "Adrian",
                    "Marty",
                    "Richard",
                    "Norbert",
                    "Kerri",
                    "Mark",
                    "Declan",
                    "Ray",
                    "Paul",
                    "Andrew",
                    "Rachel",
                    "David",
                    "Darrell"
                };
    
                Console.WriteLine("Data created");
    
                var i = 0;
                foreach (var name in testInputs)
                {
                    Console.WriteLine("Posting name {0}", i);
                    transformBlock.Post(name);
                    i++;
                }
                
                batchBlock.Complete();
                outputStringsBlock.Completion.Wait();
    
                Console.WriteLine("Finishing");
                Console.ReadKey();
            }
    
            private static void OutputStrings(IEnumerable<string> strings)
            {
                Console.WriteLine("Beginning Batch...");
                Console.WriteLine("");
    
                foreach (var s in strings)
                {
                    Console.WriteLine(s);
                }
    
                Console.WriteLine("");
                Console.WriteLine("Completing Batch...");
            }
    
            private static string TransformString(string input)
            {
                return input += " has been processed";
            }
        }
    }
