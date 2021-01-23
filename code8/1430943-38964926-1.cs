     using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://yourdomain.com");
                    client.DefaultRequestHeaders.Accept.Clear();
					
					//this line is optional in case you are using basic authentication
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                                                            "Basic",
                                                            Convert.ToBase64String(
                                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                                   string.Format("{0}:{1}", "username", "password"))));
                    var content = new FormUrlEncodedContent(new[] 
                                {
                                    new KeyValuePair<string, string>("", "login")
                                });
                    HttpResponseMessage response = client.PostAsync("http//yourdomain.com", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var _result = response.Content.ContentToString();
                        
                    }
                }
