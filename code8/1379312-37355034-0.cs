    class Program
    {
        private ConsoleKeyInfo last_key;
        private void Update()
        {
            while(last_key.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Last pressed button: " + last_key.KeyChar);
                Thread.Sleep(1000);
            }
        }
        private async Task MainProgram()
        {
            Task upd_task = Task.Run(new Action(Update));
            while(last_key.Key!=ConsoleKey.Escape)
                last_key = Console.ReadKey(true);
            await upd_task;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.MainProgram().Wait();
        }
    }
