    class Program
    {
        static string customers = "No customers";
        static void Main(string[] args)
        {
            try
            {
                GetCustomersAsync().Wait();
                Console.WriteLine(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
        static async Task GetCustomersAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.0.17:55365/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Customers");
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsStringAsync();
            }
            else customers = response.ReasonPhrase;
        }
    }
