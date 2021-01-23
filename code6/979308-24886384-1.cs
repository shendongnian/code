        if (App.current.IsRunningOutOfBrowser)
        {
            tb.Focus();
        }
        else
        {
            System.Windows.Browser.HtmlPage.Plugin.Focus();
            tb.Focus();
        }
