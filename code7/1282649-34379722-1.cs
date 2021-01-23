    class Program
    {
        static void Main(string[] args)
        {
            Task mainTask = MainAsync(args);
            mainTask.Wait();
            // Instead of writing more code here, use the MainAsync-method as your new Main()
        }
        static async Task MainAsync(string[] args)
        {
            await Send();
            Console.ReadLine();
        }
        public static async Task Send()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(2000);
            }
        }
    }
