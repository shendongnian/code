        public async Task<string> GetToken()
        {
            string token = "";
            var siteSettings = DependencyResolver.Current.GetService<SiteSettings>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(siteSettings.PopularSearchRequest.StaticApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            StatisticUserModel user = new StatisticUserModel()
            {
                Password = siteSettings.PopularSearchRequest.Password,
                Username = siteSettings.PopularSearchRequest.Username
            };
            string jsonUser = JsonConvert.SerializeObject(user, Formatting.Indented);
            var stringContent = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(siteSettings.PopularSearchRequest.StaticApiUrl + "/api/token/new", stringContent);
            token = await response.Content.ReadAsStringAsync();
            return token;
        }
