    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static bool hasRun = false;
            static void Main(string[] args)
            {
                GreetUser();// first call
                GreetUser();// second call
            }
            private static void GreetUser()
            {
                var message = "Hello, welcome. Please enter a request: ";
                // could be refactored to
                if (hasRun)
                {
                    message = "Please enter a request: ";
                }
                Console.WriteLine(message);
                var requestText = Console.ReadLine();
                hasRun = true;
            }
        }
    }
