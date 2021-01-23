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
                    new KeyValuePair<string, string>("***", "login"),
                    new KeyValuePair<string, string>("param1", "some value"),
                    new KeyValuePair<string, string>("param2", "some other value")
                });
        
         var result = client.PostAsync("/api/Membership/exists", content).Result;
     
         if (result.IsSuccessStatusCode)
            {
                Console.WriteLine(result.StatusCode.ToString());
        		string resultContent = result.Content.ReadAsStringAsync().Result;
                 Console.WriteLine(resultContent);
            }
            else
            {
                // problems handling here
                Console.WriteLine( "Error occurred, the status code is: {0}",   result.StatusCode);
            }      
            }
        }
    }
