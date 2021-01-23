    public async Task<string> GetAccessToken()
        {
            string postString = String.Format("username={0}&password={1}&grant_type=password", "userName", "pwd");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request1 = new HttpRequestMessage(HttpMethod.Post, "FeedURL");
                    request1.Content = new StringContent(postString);
                    var response = await httpClient.SendAsync(request1);
                    var result1 = await response.Content.ReadAsStringAsync();
                    result1 = Regex.Replace(result1, "<[^>]+>", string.Empty);
                    var rootObject1 = JObject.Parse(result1);
                    string accessToken = rootObject1["access_token"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }
