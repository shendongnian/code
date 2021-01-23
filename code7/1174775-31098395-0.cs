        public void GetAllCookies(HttpWebRequest req, HttpWebResponse resp)
        {
            var cookies = resp.Headers["set-cookie"];
            foreach (var cookie in cookies.Split(','))
            {
                Match match = Regex.Match(cookie, "(.+?)=(.+?);");
                if (match.Captures.Count == 0)
                    continue;
                resp.Cookies.Add(
                    new Cookie(
                        match.Groups[1].ToString(),
                        match.Groups[2].ToString(),
                        "/",
                        req.Host.Split(':')[0]));
            }
        }
