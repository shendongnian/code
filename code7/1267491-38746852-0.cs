    using System;
    using System.IO;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            var oldOut = Console.Out;
            var oldError = Console.Error;
    
            Console.SetOut(StreamWriter.Null);
            Console.SetError(StreamWriter.Null);
            Parallel.For(0, 2, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, (_) =>
            {
                try
                {
                    while(true)
                    {
                        Console.WriteLine("test message to the out stream");
                        Console.Error.WriteLine("Test message to the error stream");
                    }
                }
                catch (Exception ex)
                {
                    Console.SetOut(oldOut);
                    Console.SetError(oldError);
                    Console.WriteLine(ex);
                    Environment.Exit(1);
                }
            });
        }
    }
