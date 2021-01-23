    private void OnPageLoad(object sender, RoutedEventArgs e)
    {
        Load();
    } 
    public void Load()
    {
        var _buttonPathDataService = new ButtonPathDataService();
        try
        {
            var pdfURI = new Uri(_buttonPathDataService.GetButtonPath(Properties.Settings.Default.VideoMode));
            PDFWebBrowser.Navigate(pdfURI);
        }
        catch (Exception ex)
        {
            MessageBox.Show("No PDF linked!");
        }
    }
