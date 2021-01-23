    Using(wc = new CookieAwareWebClient())
    {
        wc.Cookies = BrowserSession.Cookies
        //Download with WebClient As normal
        wc.DownloadFile();
    }
