        private async void WebViewElm_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
          await WebViewElm.InvokeScriptAsync("callFromExternal", new string[] { txtZiel.Text });
        }
        private async void WebViewElm_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            await WebViewElm.InvokeScriptAsync("LoadingFinished", null);
        }
