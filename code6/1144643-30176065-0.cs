    public async void GetGames()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("base url");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("specific url extention (like api/Order)");
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    var deserializedResponse = JsonConvert.DeserializeObject<List<Order>>(s);
    //rest of code
                    
                }
            }
        }
