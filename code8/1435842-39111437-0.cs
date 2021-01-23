    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    
    class Program
    {
        static void Main()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6740");
                var content = new FormUrlEncodedContent(new[] 
                {
                    new KeyValuePair<string, string>("", "login")
                });
                var result = client.PostAsync("/api/Membership/exists", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }
        }
    }
