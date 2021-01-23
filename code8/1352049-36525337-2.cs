    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestModel tm = new TestModel();
                tm.examplevariable1 = Convert.ToInt32(Console.ReadLine());
                tm.examplevariable2 = Console.ReadLine();
                Thread t = new Thread(secondthread);
                t.Start(tm);
            }
    
            static void secondthread(object obj)
            {
                TestModel newTm = (TestModel) obj;
                Console.WriteLine(newTm.examplevariable1);
                Console.WriteLine(newTm.examplevariable2);
                Console.Read();
            }
    
        }
    
        class TestModel
        {
            public int examplevariable1 { get; set; }
            public string examplevariable2 { get; set; }
         
        }
    }
