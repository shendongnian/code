    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static volatile uint i;
            static uint Test()
            {
                Thread.Sleep(1000);
                i = 2; //uint.MaxValue;
                while (i-- > 0) { }
                return i;
            }
    
            static bool done;
            static async void Example()
            {
                var t = await Task.Run(() => Test());
                Console.WriteLine("result: " + t);
                done = true;
            }
            static void Main(string[] args)
            {
                Example();
                Console.WriteLine("wait: Control returns here before Example() returns ");
                while (!done) { }
                Console.WriteLine("done ");
            }
        }
    }
