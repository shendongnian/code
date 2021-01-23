        HttpResponseMessage response = client.GetAsync("api/customer/GetAll").Result;  // Blocking call!  
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
            Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
            var customerJsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Your response data is: " + customerJsonString);
        }
