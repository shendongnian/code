	string AcquireAccessToken(
            string appId,
            string appSecretKey,
            string resource,
            string userName,
            string userPassword)
    {
        Dictionary<string, string> contentValues =
            new Dictionary<string, string>()
            {
                    { "client_id", appId },
                    { "resource", resource },
                    { "username", userName },
                    { "password", userPassword },
                    { "grant_type", "password" },
                    { "client_secret", appSecretKey }
            };
        HttpContent content = new FormUrlEncodedContent(contentValues);
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            HttpResponseMessage response =
                httpClient.PostAsync(
                            "https://login.windows.net/my-crm-instance-tenant-id/oauth2/token",
                            content)
                .Result
                //.Dump() // LINQPad output
                ;
            string responseContent =
                    response.Content.ReadAsStringAsync().Result
                    //.Dump() // LINQPad output
                    ;
            if (response.IsOk() && response.IsJson())
			{
				Dictionary<string, string> resultDictionary =
					(new JavaScriptSerializer())
					.Deserialize<Dictionary<string, string>>(responseContent)
						//.Dump() // LINQPad output
						;
				
				return resultDictionary["access_token"];
			}
        }
        return null;
    }
