      WebClient wc = new WebClient();
            string baseSiteString = wc.DownloadString("https://auth-agdit.herokuapp.com");
            string csrfToken = Regex.Match(baseSiteString, "<meta name=\"csrf-token\" content=\"(.*?)\" />").Groups[1].Value;
            string cookie = wc.ResponseHeaders[HttpResponseHeader.SetCookie];
            Console.WriteLine("CSRF Token: {0}", csrfToken);
            Console.WriteLine("Cookie: {0}", cookie);
            wc.Headers.Add(HttpRequestHeader.Cookie, cookie);
            wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            wc.Headers.Add(HttpRequestHeader.Accept, "application/json, text/javascript, */*; q=0.01");
            wc.Headers.Add("X-CSRF-Token", csrfToken);
            wc.Headers.Add("X-Requested-With", "XMLHttpRequest");
            
            string dataString = @"{""user"":{""email"":""email_here"",""password"":""password_here""}}";
         //   string dataString = @"{""user"":{""email"":"""+uEmail+@""",""password"":"""+uPassword+@"""}}";
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
            byte[] responseBytes = wc.UploadData(new Uri("https://auth-agdit.herokuapp.com/api/v1/sessions.json"), "POST", dataBytes);
            string responseString = Encoding.UTF8.GetString(responseBytes);
            Console.WriteLine(responseString);
