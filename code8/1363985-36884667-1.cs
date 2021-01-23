     public static async Task<String> RunGetAsync(string param = "", bool needAuthorization = false)
            {
                HttpResponseMessage response = null;
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Url);
    
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.Timeout = TimeSpan.FromSeconds(10);
                        //if request is not allowAnonymous
                        if (needAuthorization)
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Token.Instance.Token_type, Token.Instance.Access_token);
                        }
    
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        if (string.IsNullOrEmpty(param))
                        {
                            response = await client.GetAsync(Path);
                        }
                        else
                        {
                            response = await client.GetAsync(Path + "/" + param);
                        }
    
                        if (response.IsSuccessStatusCode)
                        {
                            var stringContent = await response.Content.ReadAsStringAsync();
                            return stringContent;
    
                        }
    
                        return null;
                    }
                }
                catch (TaskCanceledException e)
                {
                    Debug.WriteLine(e.Message);
                    return null;
                }
                catch (WebException we)
                {
                    Debug.WriteLine(we.Message);
                    return null;
                }
    
    }
