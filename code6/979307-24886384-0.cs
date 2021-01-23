         If (!Application.Current.IsRunningOutOfBrowser)
            {
             System.Windows.Browser.HtmlPage.Plugin.Focus();
             TextBlock tb = new TextBlock();
             tb.Focus();
             }
