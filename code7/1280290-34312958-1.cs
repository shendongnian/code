    public void WebViewPage_Navigated(object sender, WebNavigatedEventArgs e)
    {
        WebNavigationResult result = e.Result;            
        if(result.Equals(WebNavigationResult.Success)){
            currentUrl = e.Url;
           history.Add(currentUrl);
        }            
    }
