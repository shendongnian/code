    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:9000/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // HTTP GET
        HttpResponseMessage response = await client.GetAsync("api/products");
        if (response.IsSuccessStatusCode)
        {
            IEnumerable<Product> products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
        }
    }
