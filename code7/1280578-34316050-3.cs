    class Program
    {
        static void Main(string[] args)
        {
            DoIt();
            Console.ReadLine();
        }
        static async Task DoIt()
        {
            Func<Task<int>> func = async () =>
            {
                await Task.Delay(100);
                return 1;
            };
            Throttler throttler = new Throttler(3);
            for (int i = 0; i < 10; i++)
            {
                var result = await throttler.Throttle(func);
                Console.WriteLine(DateTime.Now);
            }            
        }
    }
