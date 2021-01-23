    public static async Task RunAsync()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // HTTP POST
            var gizmo = new Product() { userid = 11, id = 100, title = "Widget11", body = "Widget11" };
            HttpResponseMessage response = await client.PostAsJsonAsync("/posts/1", gizmo).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
            }
        }
     
