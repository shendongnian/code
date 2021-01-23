     public async Task<string> GetUserDetailsAsync(string userUniqueIdentifier, HttpCookie authCookie)
                {
                    var filter = new HttpBaseProtocolFilter();
        
                    filter.CookieManager.SetCookie(authCookie);
        
                    using (var client = new HttpClient(filter))
                    {
                        var itemResult = await client.GetAsync(new Uri(BaseUrl + "/Person/" + userUniqueIdentifier));
        
                        itemResult.EnsureSuccessStatusCode();
        
                        return  = await itemResult.Content.ReadAsStringAsync();
                    }
                }
