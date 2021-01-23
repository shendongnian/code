    class Program
    {
        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadKey();
        }
        static async void MainAsync()
        {
            var task = GetNumberAsync();
            var syncNumber = GetNumber();
            var asyncNumber = await task; // moving this line above "GetNumber();" will make these run in order
            Console.WriteLine(syncNumber);
            Console.WriteLine(asyncNumber);
        }
        private static int GetNumber()
        {
            Console.WriteLine("DoSomeWork - started");
            Thread.Sleep(1000);
            Console.WriteLine("DoSomeWork - finished");
            return 11;
        }
        private static async Task<int> GetNumberAsync()
        {
            Console.WriteLine("GetNumberAsync - started");
            await Task.Delay(1000);
            Console.WriteLine("GetNumberAsync - finished");
            return 22;
        }
    }
