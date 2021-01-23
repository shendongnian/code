        //using System;
        //using System.Collections.Generic;
        //using System.Net;
        //using System.Net.Http;
        //string token = GetToken("https://localhost:<port>/", userName, password);
        static string GetToken(string url, string userName, string password) {
            var pairs = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "grant_type", "password" ), 
                            new KeyValuePair<string, string>( "username", userName ), 
                            new KeyValuePair<string, string> ( "Password", password )
                        };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient()) {
                var response = client.PostAsync(url + "Token", content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
