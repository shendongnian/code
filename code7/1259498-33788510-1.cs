     public void DownloadCookieProtectedFile(string url, string Filename)
        {
            using (CookieAwareWebClient wc = new CookieAwareWebClient())
            {
                wc.Cookies = Cookies;
                wc.DownloadFile(url, Filename);
            }
        }
    //rest of BrowserSession
