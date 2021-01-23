    // strong typed instance
    var values = new JObject();
    values.Add("FirstName", "John");
    values.Add("LastName", "Doe");
    
    // this is not set!!!
    HttpContent content = new StringContent(values.ToString(), Encoding.UTF8,"application/json");
    
    var response = client.PostAsJsonAsync("api/customer/AddNewCustomer", values).Result;
