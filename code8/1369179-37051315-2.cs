    using System;
    namespace Demo
    {
        struct Test: IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Help! Help! I'm being oppressed!");
            }
        }
        static class Program
        {
            static void Main()
            {
                using (var test = new Test())
                {
                    Console.WriteLine("Using a Test object");
                }
            }
        }
    }
