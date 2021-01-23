    namespace APIClientConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                RunAsync().Wait();
            }
            static async Task RunAsync()
            {
                using (var client = new HttpClient())
                {
                    // TODO - Send HTTP requests              
                    client.BaseAddress = new Uri("http://localhost:24780/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                    // HTTP POST                
                    var body = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", "bnk"),
                        new KeyValuePair<string, string>("password", "bnk123")                    
                    };
                    var content = new FormUrlEncodedContent(body);
                    HttpResponseMessage response = await client.PostAsync("token", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseStream = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseStream);   
                        Console.ReadLine();                 
                    }
                }
            }
        }        
    }
