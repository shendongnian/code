        public void FillCookieContainer(string cookieString, string url)
        {
            foreach (var cookieElement in cookieString.Split(';'))
            {
                CookieContainer.SetCookies(new Uri(url), cookieElement.Trim());
            }
        }
