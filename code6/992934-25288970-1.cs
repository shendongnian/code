    using System;
    using System.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static EventWaitHandle _event;
    
            static void Main(string[] args)
            {
                _event = new EventWaitHandle(false, EventResetMode.ManualReset, "foobar");
                _event.WaitOne();
                Func1();
    
                Console.ReadLine();
            }
    
            static void Func1()
            {
                Console.WriteLine("{0} - Func1() Started...", DateTime.Now);
                Thread.Sleep(500);
                Console.WriteLine("{0} - Func1() Finished..", DateTime.Now);
            }
        }
    }
