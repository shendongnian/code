    var baseAddress = "http://localhost:8010/api/customer/GetAll";
    using (var client = new HttpClient())
    {
        using (var response = await client.GetAsync(baseAddress))
        {
            if (response.IsSuccessStatusCode)
            {
                  using (HttpContent content = response.Content)
	              {
	                  string result = await content.ReadAsStringAsync();
                      var newCustomer = (customer)serializer.Deserialize(result);
                  }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    } 
