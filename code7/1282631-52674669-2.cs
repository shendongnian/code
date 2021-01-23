    class Program
    {
        static void Main(string[] args)
        {
            await SomeTask();
        }
    
        public static async Task SomeTask()
        {
            Task task = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(20000);
                Console.WriteLine("Task Completed!");
            });
            await task;
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
