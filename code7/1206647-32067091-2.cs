    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                test().Wait();
            }
            static async Task test()
            {
                try
                {
                    await Task.Run(() => throwsExceptionAfterOneSecond());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static void throwsExceptionAfterOneSecond()
            {
                Thread.Sleep(1000); // Sleep is for illustration only. 
                throw new InvalidOperationException("Ooops");
            }
        }
    }
                                                      
