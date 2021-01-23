    HttpClient client = new HttpClient();
    var content = new StringContent (json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await client.PostAsync (uri, content);
  
  ...
    if (response.IsSuccessStatusCode) 
    {
        ...
    }
