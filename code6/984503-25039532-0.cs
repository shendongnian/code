    HttpClient client;
    using (HttpResponseMessage response = client.GetAsync("http://example.info/feeds/feed.aspx?alt=json-in-script").Result)
    {
        if (response.IsSuccessStatusCode)
        {
            SomeClass Data = JsonConvert.DeserializeObject<SomeClass>(response.Content.ReadAsStringAsync().Result);
        }
    }
