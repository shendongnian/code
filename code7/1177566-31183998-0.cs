    var apiContext = new APIContext(accessToken);
            if (apiContext.HTTPHeaders == null)
            {
                apiContext.HTTPHeaders = new Dictionary<string, string>();
                apiContext.HTTPHeaders.Add("Content-Type", "application/json");
                apiContext.HTTPHeaders.Add("Authorization", accessToken);
            }
