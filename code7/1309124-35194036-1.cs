     async void PostJson(string URL, string json)
     {
         HttpClient httpClient = new HttpClient();
         httpClient.Timeout = TimeSpan.FromMinutes(5);
         httpClient.MaxResponseContentBufferSize = 25600000;
         httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
         httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
         HttpResponseMessage response = await httpClient.PostAsync(new Uri(URL), new StringContent(json, Encoding.UTF8, "application/json"));
         response.EnsureSuccessStatusCode();
         string responseAsText = await response.Content.ReadAsStringAsync();
         Dictionary<string, string> responseJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseAsText);
     }
