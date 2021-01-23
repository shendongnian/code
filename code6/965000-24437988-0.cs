    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TaskWhenAllTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Task task = Test();
    
                    Task.WaitAll(new Task[] { task });
    
                    Console.WriteLine(task.Status);
                }
                catch (Exception)
                {
                    //Console.WriteLine(ex.ToString());
                    Console.WriteLine("Task errored.");
                }
    
                Console.WriteLine("Done.");
                Console.ReadKey();
            }
    
            static async Task Test()
            {
                var task1 = Task.Factory.StartNew(() => { System.Threading.Thread.Sleep(1000); throw new Exception("Test1 exception"); });
                var task2 = Task.Factory.StartNew(() => { System.Threading.Thread.Sleep(500); Console.WriteLine("Task 2 complete."); });
                var task3 = Task.Factory.StartNew(() => { System.Threading.Thread.Sleep(250); Console.WriteLine("Task 3 complete."); });
    
                await Task.WhenAll(new Task[] {task1, task2, task3 });
            }
        }
    }
