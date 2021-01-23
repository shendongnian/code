            var wc2 = new WebClient();
            string baseSiteString2 = wc2.DownloadString("https://sample.com");
            string csrfToken2 = Regex.Match(baseSiteString2, "<meta name=\"csrf-token\" content=\"(.*?)\" />").Groups[1].Value;
            string cookie2 = wc2.ResponseHeaders[HttpResponseHeader.SetCookie];
            wc2.Headers.Add(HttpRequestHeader.Cookie, cookie2);
            wc2.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            wc2.Headers.Add(HttpRequestHeader.Accept, "application/json, text/javascript, */*; q=0.01");
            wc2.Headers.Add("X-CSRF-Token", csrfToken2);
            wc2.Headers.Add("X-Requested-With", "XMLHttpRequest");
           
                 
            string dataString2 = "";// @"{""name"":""Megan"",""regi_number"":4444}";
            byte[] dataBytes2 = Encoding.UTF8.GetBytes(dataString2);
            string finalUrl = "https://sample.com?authentication_token=" + authentication_token;
            byte[] responseBytes2 = wc2.UploadData(new Uri(finalUrl), "DELETE", dataBytes2);
            string responseString2 = Encoding.UTF8.GetString(responseBytes2);
            authentication_token = "";         
