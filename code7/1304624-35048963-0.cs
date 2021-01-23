        public async Task<string> GetXMl(string uri)
        {
            string result = null;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
