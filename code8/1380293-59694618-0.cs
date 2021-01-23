    public async void ExecuteJavaScript(string script)
        {
            if (browser != null)
                if (browser.CanExecuteJavascriptInMainFrame)
                {
                    System.Windows.Forms.MessageBox.Show(browser.IsLoaded.ToString());
                    if(browser.IsLoaded == true)
                    browser.ExecuteScriptAsync(script);
                }
                    await Task.Delay(5000);
        }
