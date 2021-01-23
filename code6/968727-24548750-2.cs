    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://www.url.com/");
        client.Content = new StringContent(jsonEncodedCredentials, Encoding.UTF8, "application/json"))
        HttpResponseMessage response = await client.PostAsync("api/login");
        if (response.IsSuccessStatusCode)
        {
            string jsonEncodedReponse = await response.Content.ReadAsStringAsync();
            //Do something with the response
        }
    }
