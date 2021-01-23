        public async Task<string> GetData()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage responseMessage = client.GetAsync("http://planer.info.pl/api/rest/places.json").Result;
                    if (responseMessage.IsSuccessStatusCode)
                        return await responseMessage.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }
    String response = await GetData();
