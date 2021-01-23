        [HttpGet]
        public async Task<JObject> SendOtp(string number)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                client.BaseAddress = new Uri("https://api.textlocal.in/");
                client.DefaultRequestHeaders.Add("accept","application/json");
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["apikey"] = ".....";
                query["numbers"] = ".....;
                query["message"] = ".....";
                var response = await client.GetAsync("send?"+query);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JObject.Parse(content);
            }
        }
