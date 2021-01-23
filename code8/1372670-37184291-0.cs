     AuthenticationContext authenticationContext = new AuthenticationContext("https://login.windows.net/" + Constants.TenantName, false);
                var clientCredential = new ClientCredential(Constants.ClientId, Constants.ClientSecret);
                AuthenticationResult authenticationResult = authenticationContext.AcquireToken("https://graph.microsoft.com/", clientCredential);
                string token = authenticationResult.AccessToken;
                string content = @"{
                  ""displayName"": ""mailgrouptest"",      
                  ""groupTypes"": [""Unified""],
                  ""mailEnabled"": true,
                  ""mailNickname"": ""mailalias"",
                  ""securityEnabled"": false
                }";
                using (var client = new HttpClient())
                {
                    string uri = "https://graph.microsoft.com/v1.0/groups"
                    using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        string json = content;
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                        using (HttpResponseMessage response = client.SendAsync(request).Result)
                        {
                            //response.IsSuccessStatusCode
                        }
                    }
                }
