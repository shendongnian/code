            string login_info = "login=login&redirect=http%3A%2F%2F"+WebUtility.UrlEncode(populated_config.domain)+"%2Fchat%2F%3FchannelName%3DPublic&username=" + WebUtility.UrlEncode(populated_config.username) + "&password=" + WebUtility.UrlEncode(populated_config.password) + "&channelName=Public&lang=en&submit=Login";
            request = (HttpWebRequest)WebRequest.Create(populated_config.domain + "ucp.php?mode=login");
            request.Method = "POST";
            //manually populate cookies
            Console.WriteLine(cc.GetCookieHeader(new Uri(populated_config.domain)));
            request.Headers.Add(HttpRequestHeader.Cookie,cc.GetCookieHeader(new Uri(populated_config.domain)));
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(login_info);
            response = (HttpWebResponse)request.GetResponse();
