    class Program
    {
        public static async Task<HttpResponseMessage> CallAsyncMethod()
        {
            Console.WriteLine("Calling Youtube");
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://www.youtube.com/watch?v=_OBlgSz8sSM");
            Console.WriteLine("Got Response from youtube");
            return response;
        }
        private static async Task Run()
        {
            HttpResponseMessage response = await CallAsyncMethod();
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Run().Wait();
        }
    }
