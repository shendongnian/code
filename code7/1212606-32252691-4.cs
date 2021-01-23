        public async Task<Address[]> GetAddresses() {
            var client = new HttpClient {BaseAddress = new Uri(_settingsService.GetHost())};
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var base64 = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "myuser", "test")));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",base64);
            HttpResponseMessage response = await client.GetAsync("api/addresses");
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ReasonPhrase);
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address[]>(content);
        } 
