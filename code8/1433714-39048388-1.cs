    class Program
    {
        static void Main()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://yourapp");
                var content = new FormUrlEncodedContent(new[] 
                {
                    // Push your stuff here, your username, password fields 
                    // as you coded in your server
                    new KeyValuePair<string, string>("", "login")
                });
                var result = client.PostAsync("login", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }
        }
    }
