    private async Task LoadImageAsync()
    {
       TimeSpan delay = new TimeSpan(0, 0, 0, 0, 0);      
       var bitmap = await BitmapFromUriAsync(new Uri(compPath + oComps[nCount].name);
       Fader.ChangeSource(image, bitmap), delay, delay);
       image.Visibility = System.Windows.Visibility.Visible;
       mediaElement.Stop();
       mediaElement.Close(); ;
       mediaElement2.Stop();
       mediaElement2.Close();
       mediaElement.Visibility = System.Windows.Visibility.Collapsed;
    }
