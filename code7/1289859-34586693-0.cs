    var client = new HttpClient();
    client.BaseAddress = new Uri("http://mybaseaddress/");
    HttpResponseMessage response = await client.GetAsync("someEndpoint");
    if (response.IsSuccessStatusCode)
     {
       var model = await response.Content.ReadAsAsync<MyModel>();                
     }
