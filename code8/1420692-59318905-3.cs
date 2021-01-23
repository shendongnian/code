    public static async Task<Resource> GetResource()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("api/session");
                if (response.StatusCode != HttpStatusCode.OK)
                    return null;
                var resourceJson = await response.Content.ReadAsStringAsync();
                return JsonUtility.FromJson<Resource>(resourceJson);
            }
        }
