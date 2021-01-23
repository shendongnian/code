    public static string GetPageAccessToken(string userAccessToken)
        {
            FacebookClient fbClient = new FacebookClient();
            fbClient.AppId = "*****";
            fbClient.AppSecret = "**************";
            fbClient.AccessToken = userAccessToken;
            Dictionary<string, object> fbParams = new Dictionary<string, object>();
            JsonObject publishedResponse = fbClient.Get("/me/accounts", fbParams) as JsonObject;
            JArray data = JArray.Parse(publishedResponse["data"].ToString());
    
            foreach (var account in data)
            {
                if (account["name"].ToString().ToLower().Equals("opening shortly"))
                {
                    return account["access_token"].ToString();
                }
            }
            return String.Empty;
        }
