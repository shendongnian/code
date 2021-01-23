            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Ionic-Application-Id", IONIC_APP_ID);
                var keyBase64 = "Basic " + IONIC_PRIVATE_KEY_BASE_64;
                client.DefaultRequestHeaders.Add("Authorization", keyBase64);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, api);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.SendAsync(request).Result;                
            }
