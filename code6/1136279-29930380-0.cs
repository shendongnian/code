    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://myUrl");
        var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
        response = await client.PostAsJsonAsync("api/products", gizmo);
        if (response.IsSuccessStatusCode)
        {
            //do something
        }
    }
