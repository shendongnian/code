    class MainClass
    {
        public static HttpClient client = new HttpClient();
        static string url = "http://www.website.com";
        public static async Task getSessionAsync()
        {
            StringContent queryString = new StringContent("{json:here}");
            // Send a request asynchronously continue when complete
            using (HttpResponseMessage result = await client.PostAsync(url, queryString))
            {
                // Check for success or throw exception
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }
        public static async Task RunAsync()
        {
            await getSessionAsync();
            // Not yet implemented yet..
            //doMore ();
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            // Send the request 2 times in parallel - can be more than 2 if needed
            Task.WhenAll(getSessionAsync(), getSessionAsync()).GetAwaiter().GetResult();
            // It would be better to do Task.WhenAny() in a while loop until one of the task succeeds
            // We could add cancellation of other tasks once we get a successful response
        }
    }
