            static string GetToken(string userName, string password)
            {
                var pairs = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>( "grant_type", "password" ), 
                                new KeyValuePair<string, string>( "userName", userName ), 
                                new KeyValuePair<string, string> ( "password", password )
                            };
                var content = new FormUrlEncodedContent(pairs);
                using (var client = new HttpClient())
                {
                    var response = 
                        client.PostAsync("https://localhost:12698/Token", content).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
