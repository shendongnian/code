    public class AccessTokenModel
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
        
    public static string GetToken()
                {
                    using (HttpClient client = new HttpClient())
                    {
    
                    client.BaseAddress = new Uri("https://login.microsoftonline.com");
    
                    var content = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("client_id", 'yourAppId'),
                    new KeyValuePair<string, string>("client_secret", 'yourAppPassword'),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "emailAddress"),
                    new KeyValuePair<string, string>("password", "emailPassword"),
                    new KeyValuePair<string, string>("resource", "https://graph.microsoft.com"),
                    new KeyValuePair<string, string>("scope", "openid")
                    });
    
                    var result = client.PostAsync($"/common/oauth2/token", content);
                    var resultContent = result.Result.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<AccessTokenModel>(resultContent.Result);
    
                    return model.AccessToken;
    
                }
            }
