    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(" http://localhost:46789/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.GetAsync("api/Trinity/GetDirectoryAndTask/9/AG33%2f34");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsAsync<KeyValuePair<string, string>>();
            //The result is a valid key/value pair
        }
    }
