    using (var client = new HttpClient())
    {
        // New code:
        client.BaseAddress = new Uri("Your API URL");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    } 
