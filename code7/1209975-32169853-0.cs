    public async Task<Uri> Post<T>(T obj, Uri url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(url, obj);
                response.EnsureSuccessStatusCode();             
                return response.Headers.Location;
            }
        }
