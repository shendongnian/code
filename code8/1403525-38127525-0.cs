    using System;
    using System.Threading.Tasks;
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                MainAsync(args).GetAwaiter().GetResult();
                Console.ReadKey();
            }
    
            public static async Task MainAysnc(string[] args)
            {
                await Task.Delay(1000);
                Console.WriteLine("Hello World!");
            }
        }
    }
