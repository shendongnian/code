    public string postPinterest(string access_token,string boardname,string note,string image_url)
          {
    
                public string pinSharesEndPoint = "https://api.pinterest.com/v1/pins/?access_token={0}";
    
                var requestUrl = String.Format(pinSharesEndPoint, accessToken);
                var message = new
                {
                     board = boardname,
                     note = note,
                     image_url = image_url
                };
    
                var requestJson = new JavaScriptSerializer().Serialize(message);
    
                var client = new WebClient();
                var requestHeaders = new NameValueCollection
    {
    
        {"Content-Type", "application/json" },
                {"x-li-format", "json" }
    
    };
                client.Headers.Add(requestHeaders);
                var responseJson = client.UploadString(requestUrl, "POST", requestJson);
                var response = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(responseJson);
                return response;
    }
