    private async void MyWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
                string result = await this.MyWebView.InvokeScriptAsync("eval", new string[] { "window.confirm = function (ConfirmMessage) {window.external.notify(ConfirmMessage)}" });
        }
    private async void MyWebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            
                Windows.UI.Popups.MessageDialog dialog = new Windows.UI.Popups.MessageDialog(e.Value);
                dialog.Commands.Add(new UICommand("Yes"));
                dialog.Commands.Add(new UICommand("No"));
                // Set the command that will be invoked by default
                dialog.DefaultCommandIndex = 0;
                // Set the command to be invoked when escape is pressed
                dialog.CancelCommandIndex = 1;
                var result = await dialog.ShowAsync();
                if (result.Label.Equals("Yes"))
                {
                    string res = await MyWebView.InvokeScriptAsync("eval", new string[] { "window.confirm = function (ConfirmMessage) {return true}" });
                }
                else
                {
                    string res = await MyWebView.InvokeScriptAsync("eval", new string[] { "window.confirm = function (ConfirmMessage) {return false}" });
                }
        }
