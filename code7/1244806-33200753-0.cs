    public void SetMultipleCookies(string cookieName, Dictionary<string, string> dic, HttpCookie cookie)
        {
            foreach (KeyValuePair<string, string> val in dic)
            {
                cookie.Values.Add(val.Key, val.Value);
            }
            
            cookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
