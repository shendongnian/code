        private void NavigateWithHeader(Uri uri)
        {
            var requestMsg = new Windows.Web.Http.HttpRequestMessage(HttpMethod.Get, uri);
            requestMsg.Headers.Add("User-Name", "Franklin Chen");
            wb.NavigateWithHttpRequestMessage(requestMsg);
            wb.NavigationStarting += Wb_NavigationStarting;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateWithHeader(new Uri("http://openszone.com/RedirectPage.html"));
        }
        private void Wb_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            wb.NavigationStarting -= Wb_NavigationStarting;
            args.Cancel = true;//cancel navigation in a handler for this event by setting the WebViewNavigationStartingEventArgs.Cancel property to true
            NavigateWithHeader(args.Uri);
        }
