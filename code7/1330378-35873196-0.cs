        private static void Main(string[] args)
        {
            GetValue();
            Console.WriteLine("test1");
            Console.WriteLine("1 " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        private static async void GetValue()
        {
            Console.WriteLine(await AccessTheWebAsync());
            Console.WriteLine("2 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("test2");
            Console.WriteLine("3 " + Thread.CurrentThread.ManagedThreadId);
        }
        private static async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            Console.WriteLine("4 " + Thread.CurrentThread.ManagedThreadId);
            string urlContents = await getStringTask;
            Console.WriteLine("5 " + Thread.CurrentThread.ManagedThreadId);
            return urlContents.Length;
        }
