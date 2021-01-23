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
           var worker = Task<Bitmap>.Factory.StartNew(() =>        
                          baseSource?.ConvertToBitmap()
                         .CompareTo(newSource?.ConvertToBitmap()));
            var bmp = await worker;
            
            // The next statement is executed in UI synchronization context
            imageNew.Source = bmp.BitmapToImageSource(); 
              
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
