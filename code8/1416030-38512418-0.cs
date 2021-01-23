    public static  async Task UploadAsync(ReadingModel reading)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://your-api-domain.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // HTTP GET
            HttpResponseMessage response = await client.GetAsync("api/yourapi");
            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadAsAsync<Product>();
                Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
            }
            // HTTP POST
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/yourapi", reading);
                if (response.IsSuccessStatusCode)
                {
                    // do your stuff
                }
            }
            catch (Exception)
            {
                
            }
            
        }
    }
