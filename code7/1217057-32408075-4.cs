    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var content = webBrowser1.DocumentText;
        var regex = new Regex(@"\<title\>(.+?)=(.+?)\</title\>");
        var match = regex.Match(content);
        if (!match.Success || match.Groups.Count != 3)
            return;
        switch (match.Groups[1].Value.ToLowerInvariant())
        {
            case "code": // we have a code
                var code = match.Groups[2].Value;
                var config = new ApiConfiguration(Configuration.ClientId, Configuration.ClientSecret, Configuration.RedirectUrl);
                var service = new OAuthService(config, new WebRequestFactory(config));
                var tokens = service.GetTokensAsync(code).Result; // <= blocking
                _keyService.OAuthResponse = tokens;
                break;
            case "error": // user probably said "no thanks"
                webBrowser1.Navigate(_logoffUri);
                break;
        }
    } 
