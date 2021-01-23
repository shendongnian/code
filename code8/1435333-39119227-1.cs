    private async void Border_Tapped(object sender, TappedRoutedEventArgs e)
    {
        await TakePhotoAsync();
    }
    
    private async void Border_Holding(object sender, HoldingRoutedEventArgs e)
    {
        await StartRecordingAsync();
    }
