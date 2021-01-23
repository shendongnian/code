    using (HttpClient http = new HttpClient())
    {
        using (var response = await http.GetAsync(new Uri(_url)))
        {
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                return XDocument.Load(stream);
            }
        }
    }
