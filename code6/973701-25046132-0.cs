     var count = "5";                //*****************************************************************
        var exclude_replies = "true";  //******************************************************************
        var baseFormat = "count={7}&exclude_replies={8}&oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" + //************************
                        "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&q={6}";
        var baseString = string.Format(baseFormat,
                                    oauth_consumer_key,
                                    oauth_nonce,
                                    oauth_signature_method,
                                    oauth_timestamp,
                                    oauth_token,
                                    oauth_version,
                                    Uri.EscapeDataString(q),
                                    Uri.EscapeDataString(count),          //*****************************************
                                    Uri.EscapeDataString(exclude_replies)//*******************************************
                                    );
        baseString = string.Concat("GET&", Uri.EscapeDataString(url), "&", Uri.EscapeDataString(baseString));//
        var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                                "&", Uri.EscapeDataString(oauth_token_secret));
        string oauth_signature;
        using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
        {
            oauth_signature = Convert.ToBase64String(
                hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
        }
        // create the request header
        var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                           "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                           "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                           "oauth_version=\"{6}\"";
        var authHeader = string.Format(headerFormat,
                                Uri.EscapeDataString(oauth_nonce),
                                Uri.EscapeDataString(oauth_signature_method),
                                Uri.EscapeDataString(oauth_timestamp),
                                Uri.EscapeDataString(oauth_consumer_key),
                                Uri.EscapeDataString(oauth_token),
                                Uri.EscapeDataString(oauth_signature),
                                Uri.EscapeDataString(oauth_version)
                        );
        ServicePointManager.Expect100Continue = false;
        // make the request
        var postBody = string.Format("q={0}&count={1}&exclude_replies={2}", Uri.EscapeDataString(q),Uri.EscapeDataString(count),Uri.EscapeDataString(exclude_replies));//***
        url += "?" + postBody;//
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//
        request.Headers.Add("Authorization", authHeader);
        request.Method = "GET";
        request.ContentType = "application/x-www-form-urlencoded";
        var response = (HttpWebResponse)request.GetResponse();
        var reader = new StreamReader(response.GetResponseStream());
        var objText = reader.ReadToEnd();
        myDiv.InnerHtml = objText;/**/
        string html = "";
        try
        {
            JArray jsonDat = JArray.Parse(objText);
            for (int x = 0; x < jsonDat.Count(); x++)
            {
                //html += jsonDat[x]["id"].ToString() + "<br/>";
                html += jsonDat[x]["text"].ToString() + "<br/>";
                // html += jsonDat[x]["name"].ToString() + "<br/>";
               //html += jsonDat[x]["created_at"].ToString() + "<br/>";
            }
            myDiv.InnerHtml = html;
        }
        catch (Exception twit_error)
        {
            myDiv.InnerHtml = html + twit_error.ToString();
        }
    }
}
