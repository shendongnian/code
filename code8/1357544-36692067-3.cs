     private void OpenBrowser(PaymentViewModel viewModel, Uri uri)
     {
        viewModel.BrowserWindow = new WithoutCloseButton();
        viewModel.BrowserWindow.Closed += BrowserWindow_Closed;
        var browser = new MyWebBrowser();
        var stackPanel = new StackPanel { Orientation = System.Windows.Controls.Orientation.Vertical };
        var formsHost = new WindowsFormsHost {Child = browser};
        stackPanel.Children.Add(formsHost);
        viewModel.BrowserWindow.Content = stackPanel;
    //....    then            
     browser.Navigate("about:blank");
     browser.DocumentCompleted += delegate(object obj, WebBrowserDocumentCompletedEventArgs e)
    {
        if (e.Url.ToString() == "about:blank")
        {
            ((MyWebBrowser)obj).Navigate(uri);
        }
        if (e.Url.ToString().ToLower().Contains("accepted"))
        {
            ViewModel.AuthCode = this.GetAuthToken();
            ViewModel.updateUiWhenDoneWithPayment_RunWorkerCompleted(new object(), null);
            ViewModel.BrowserWindow.Close();
            ViewModel.BrowserWindow = null;
        }
        //THIS IS NEW
        if (e.Url.ToString().ToLower().Contains("payment/confirmation"))
        {
            viewModel.BrowserWindow.HideButtons();
        }
    };
