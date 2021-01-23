    public async Task<Resource> GetResource()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.yourAPI.com/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync("api/resource");
            if (response.StatusCode != HttpStatusCode.OK)
                return null;
            var resourceJson = response.Content.ReadAsStringAsync().Result;
            var resource = JsonUtility.FromJson<Resource>(resourceJson);
            return resource;
        }
