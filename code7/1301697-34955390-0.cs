    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Task.Factory.StartNew(() => MethodA())
                    .ContinueWith(a =>
                    {
                         MethodB();
                    });
    
                Console.WriteLine("Press a key to exit");
                Console.ReadKey(false);
    
            }
    
            public static void MethodA()
            {
                Thread.Sleep(2000);
                Console.WriteLine("Hello From method A {0}", Thread.CurrentThread.ManagedThreadId);
            }
    
            public static void MethodB()
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello From method B {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
