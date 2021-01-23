    //After loading web page contents into browser get input as
    private void FillAuthentication(string username, string password)
    {
        if (_mainDialog.WebBrowser.Document == null) return;
        var tagsColl = _mainDialog.WebBrowser.Document.GetElementsByTagName("input");
        foreach (GeckoElement currentTag in tagsColl)
        {
            if (currentTag.TagName.Equals("email"))
                currentTag.SetAttribute("value", username);
            if (currentTag.TagName.Equals("pass"))
                currentTag.SetAttribute("value", password);
        }
    }
