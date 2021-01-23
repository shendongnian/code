    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(Shared.URL);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Shared.HeaderType));
        string jsonInput = JsonConvert.SerializeObject(customer);
        HttpContent contentPost = new StringContent(jsonInput, Encoding.UTF8, "application/json");
       var response = client.PostAsync("http://myuri/api/Customer/Add", contentPost).Result;
        response.EnsureSuccessStatusCode();
        string json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Model.CustomerAddress>(json);
    }
