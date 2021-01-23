    using System;
    using System.Threading;
    
    
        namespace ConsoleApplication
        {
            public class Program
            {
                public static void Main(string[] args)
                {
                    Console.WriteLine(DateTime.Now);
                    Thread.Sleep(2000);
                    Console.WriteLine("Hello World!");
                    Console.WriteLine(DateTime.Now);
                }
            }
        }
