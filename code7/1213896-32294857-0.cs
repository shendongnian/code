    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost/api/v1/");
    
    HttpResponseMessage response = await client.GetAsync("some");
    
    if(response.IsSuccessfulStatusCode)
    {
         // The entity is within the response's content
         RootObject root = await response.Content.ReadAsAsync<RootObject>();
    }
