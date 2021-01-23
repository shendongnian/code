        String range = "Config!A2:E";
        ValueRange valueRange=new ValueRange();
        valueRange.Range = range;
        valueRange.MajorDimension = "ROWS";//"ROWS";//COLUMNS
        var oblist=new List<object>(){12,3,4,5u,6};
        valueRange.Values = new List<IList<object>> {oblist};
        var url = "https://sheets.googleapis.com/v4/spreadsheets/{spreadsheetId}/values/{range}?valueInputOption=RAW".Replace("{spreadsheetId}",spreadsheetId).Replace("{range}", HttpUtility.UrlEncode(range));
        JObject json = null;
        using (var client = new WebClient())
        {
            client.Headers.Set("Authorization", "Bearer " + credential.Token.AccessToken);
            client.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            client.Headers.Set(HttpRequestHeader.UserAgent, "myprogram database updater google-api-dotnet-client/1.13.1.0 (gzip)");
            ServicePointManager.Expect100Continue = false;
            var jsonstr = JsonConvert.SerializeObject(valueRange);
            var jsontemp = JObject.Parse(jsonstr);
            jsontemp.Remove("ETag");
            jsonstr = jsontemp.ToString();
            try
            {
                var res = client.UploadString(url, "PUT", jsonstr);
                json = JObject.Parse(res);
            }
            catch (Exception)
            {
            }
        }`
