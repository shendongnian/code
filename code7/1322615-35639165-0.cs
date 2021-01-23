      using (var client = new HttpClient(new NativeMessageHandler()) { BaseAddress = new Uri(Settings.TokenUrl) })
                {
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "refresh_token"),
                        new KeyValuePair<string, string>("refresh_token", Settings.RefreshToken),
                        new KeyValuePair<string, string>("client_id", Settings.ClientId),
                        new KeyValuePair<string, string>("client_secret", Settings.ClientSecret)
                    }); 
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                    var response = await client.PostAsync(client.BaseAddress, formContent);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        var json = JObject.Parse(jsonResult);
                        Settings.RefreshToken = json["refresh_token"].ToString();
                        Settings.AccessToken = json["access_token"].ToString();
                        
                    }
                  
                }
