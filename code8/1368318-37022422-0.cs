         bool done = false;
                private void WebView_Navigation_Starting(WebView sender, WebViewNavigationStartingEventArgs args)
                {
     progressIndicator.Visibility = Visibility.Visible;
            args.Cancel = true;
    
            // external URL
            if (isExternalUrl(args.Uri.AbsoluteUri))
            {
                //cancel load
                args.Cancel = true;
                //launch default browser
                await Launcher.LaunchUriAsync(args.Uri);
    
                progressIndicator.Visibility = Visibility.Collapsed;
            }
            else
            {
                    if (!done)
                    {
                        done = true;
                        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, args.Uri);
                        foreach (KeyValuePair<String, String> header in additionalHeaders)
                        {
                           httpRequestMessage.Headers.Add(header);
                        }
                        webView.NavigateWithHttpRequestMessage(httpRequestMessage);
                       
                    }
             }
    }
