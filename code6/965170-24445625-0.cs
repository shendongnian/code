    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AsyncCheckerTest
    {
        public class Checker
        {
            public int Seconds { get; private set; }
    
            public Checker(int seconds)
            {
                Seconds = seconds;
            }
    
            public async Task<bool> CheckAsync()
            {
                await Task.Delay(Seconds * 1000);
                return Seconds != 3;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var task = RunAsync();
                task.Wait();
    
                Console.WriteLine("Overall result: " + task.Result);
                Console.ReadLine();
            }
    
            public static async Task<bool> RunAsync()
            {
                var checkers = new List<Checker>();
                checkers
                    .AddRange(Enumerable.Range(1, 5)
                    .Select(i => new Checker(i)));
    
                return await checkers
                                .Select(c => c.CheckAsync())
                                .AllAsync();
            }
        }
    
        public static class ExtensionMethods
        {
            public static async Task<bool> AllAsync(this IEnumerable<Task<bool>> source)
            {
                var tasks = source.ToList();
    
                while (tasks.Count != 0)
                {
                    Task<bool> finishedTask = await Task.WhenAny(tasks);
    
                    bool checkResult = finishedTask.Result;
    
                    if (!checkResult)
                    {
                        Console.WriteLine("Completed at " + DateTimeOffset.Now + "...false");
                        return false;
                    }
    
                    Console.WriteLine("Working... " + DateTimeOffset.Now);
                    tasks.Remove(finishedTask);
                }
    
                return true;
            }
        }
    }
    
