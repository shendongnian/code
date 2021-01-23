    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://www.url.com/");
        client.Content = new StringContent(jsonEncodedCredentials, Encoding.UTF8, "application/json"))
        HttpResponseMessage response = await client.PostAsync("api/login");
        if (response.IsSuccessStatusCode)
        {
            HttpResponseMessage response = await response.Content.ReadAsAsync<Product>();
            //read response..
        }
    }
