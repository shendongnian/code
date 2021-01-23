    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Stopwatch sw = new Stopwatch();
                var task = new Task(() => 
                {
                    sw.Start();
                    someMethod();
                });
                task.Start();
                task.ContinueWith(antecedent => 
                {
                    if (sw.ElapsedMilliseconds >= 1000 )
                        Console.WriteLine("Took at least second.");
                    else
                        Console.WriteLine("Took less than a second.");
                });
                Console.WriteLine("Press <ENTER> to exit.");
                Console.ReadLine();
            }
            static void someMethod()
            {
                Thread.Sleep(2000);
            }
        }
    }
