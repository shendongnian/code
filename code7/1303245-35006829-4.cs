    public async Task<ItemResult> PostItem()
    {
        var item = new Item(1, 0, "Posted Item Name 6", "Posted Item Data");
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = await client.PostAsJsonAsync("api/Postitem", item))
            using (var rs = await response.Content.ReadAsStreamAsync())
            using (var sr = new StreamRead(rs))
            using (var jr = new JsonTextReader(sr))
            {
                if (response.IsSuccessStatusCode)
                {
                    return serializer.Deserialize<ItemResult>(jr);
                }
                else
                {
                    //deserialize as something else...an error message perhaps?
                }
            }
        }
    }
