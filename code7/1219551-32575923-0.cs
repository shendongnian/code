    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://graph.windows.net/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        HttpResponseMessage response = await client.GetAsync("DOMAIN/users/?$expand=manager&api-version=2013-11-08");
        if (response.IsSuccessStatusCode)
        {
             // TODO: Deserialize the response here...
        }
    }
