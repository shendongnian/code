    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace ConsoleApplication8
    {
        class Program
        {
            static readonly BlockingCollection<int> List = new BlockingCollection<int>();
            static void Main(string[] args)
            {
                var application = NewMethod();
                application.Wait();
                Console.ReadLine();
            }
            private async static Task NewMethod()
            {
                var tasks = new List<Task>();
                for (int i = 0; i < 100; i++)
                {
                    tasks.Add(Func(i));
                }
                Console.WriteLine("Lol");
                await Task.WhenAll(tasks);
                Console.WriteLine(List.Sum());
            }
            static async Task Func(int i)
            {
                await Task.Delay(100);
                List.Add(i);
            }
        }
    }
