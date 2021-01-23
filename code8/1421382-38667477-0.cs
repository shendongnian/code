    using (var client = new WebClient())
                {
                    var values = new Dictionary<string, string>
        {
           { "accesstoken", authtoken },
           { "programid", programid.ToString()},
           { "email", person.Email },
           { "thirdparty1", person.ID.ToString() }
        };
    
                    var param = string.Join("&", values.Select(x => x.Key + "=" + x.Value).ToArray());
    
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = client.UploadString(URI, "POST", param);
                }
