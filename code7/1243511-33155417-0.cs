    private void PrintDocument(Uri uri)
    {
        var wb = new System.Windows.Forms.WebBrowser();
        wb.DocumentCompleted += PageLoaded;
        wb.Url = uri;
    }
    private void PageLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        ((System.Windows.Forms.WebBrowser)sender).Print();
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var url = new Uri(@"C:\Users\EACD-017\Documents\Host.html");
        PrintDocument(url);
    }
