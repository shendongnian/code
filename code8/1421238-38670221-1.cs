        //using System;
        //using System.Collections.Generic;
        //using System.Net;
        //using System.Net.Http;
        //var result = CallApi("https://localhost:<port>/something", token);
        static string CallApi(string url, string token) {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient()) {
                if (!string.IsNullOrWhiteSpace(token)) {
                    var t = JsonConvert.DeserializeObject<Token>(token);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + t.access_token);
                }
                var response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
