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
            // Write your programs code here, You can freely use the async / await pattern
        }
    }
