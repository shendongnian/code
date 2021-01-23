     private static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await Send();
            }).Wait();
        }
        public static async Task Send()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(2000);
            }
        }
 
