    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int examplevariable = Convert.ToInt32(Console.ReadLine());
                Thread t = new Thread(secondthread);
                t.Start(examplevariable);
            }
    
            static void secondthread(object obj)
            {
                int examplevariable = (int) obj;
                Console.WriteLine(examplevariable);
                Console.Read();
            }
    
        }
    }
