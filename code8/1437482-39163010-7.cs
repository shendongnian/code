        HttpResponseMessage response = client.GetAsync("api/customer/GetAll").Result;  // Blocking call!  
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
            Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
            // Get the response
            var customerJsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Your response data is: " + customerJsonString);
            
            // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Customer>>(custome‌​rJsonString);
            // Do something with it
        }
