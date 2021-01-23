    async Task<BitmapSource> DoAnalyzeAsync( BitmapSource  source, BitmapSource newSource)
    {
       var worker = Task<Bitmap>.Factory.StartNew(() => baseSource?.ConvertToBitmap()
                         .CompareTo(newSource?.ConvertToBitmap()));
       var bmp = await worker;
       return bmp.BitmapToImageSource(); //Will be executed in UI synchronization context
  }
    private async void btnAnalyze_Click(object sender, RoutedEventArgs e)
    {
        if (AnalyzeImage?.Status == TaskStatus.Running) await AnalyzeImage;
        var baseSource = (BitmapSource)imgBase.Source;
        var newSource = (BitmapSource)imgNew.Source;
        if (baseSource?.CompareSizeTo(newSource) == false)
        {
            ShowStatus("Images are different in size or at least one of them is null");
            return;
        }
        btnAnalyze.IsEnabled = false;
        ShowStatus();
        try
        {
           waitingPanel.Visibility = Visibility.Visible;
           imgNew.Source = await DoAnalyzeAsync(baseSource, newSource);   
        }
        catch (Exception ex) 
        { 
           Notify("Error in btnAnalyzeClick", ex, true); 
        }
        finally 
        { 
           waitingPanel.Visibility = Visibility.Hidden;
        }
     }
