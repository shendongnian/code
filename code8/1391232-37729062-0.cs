    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ActionsLog = new Dictionary<string, Action[]>();
    
                ActionsLog.Add("T1", new Action[]
                {
                    () =>
                    {
                        Console.WriteLine("Test1");
                        Thread.Sleep(2000);
                    },
                    () => Console.WriteLine("LogTest1")
                });
                ActionsLog.Add("T2", new Action[] { () => {
                        Console.WriteLine("Test2");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest2") });
                ActionsLog.Add("T3", new Action[] { () => {
                        Console.WriteLine("Test3");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest3") });
                ActionsLog.Add("T4", new Action[] { () => {
                        Console.WriteLine("Test4");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest4") });
                ActionsLog.Add("T5", new Action[] { () => {
                        Console.WriteLine("Test5");Thread.Sleep(2000);}, () => Console.WriteLine("LogTest5") });
                ActionsLog.Add("T6", new Action[]
                {
                    () =>
                    {
                        Console.WriteLine("Test6");
                        Thread.Sleep(2000);
                    },
                    () => Console.WriteLine("LogTest6")
                });
    
    
    
    
                var origin = Task.Factory.StartNew(() => { });
                var runner = origin;
                foreach (var action in ActionsLog.Values.SelectMany(x => x))
                {
                    runner = runner.ContinueWith(prev => action());
                }
               
                origin.Wait();
    
    
                Console.ReadLine();
            }
        }
    }
