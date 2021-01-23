    private ImageSource IconToImageSource(System.Drawing.Icon icon)
    {
        return Imaging.CreateBitmapSourceFromHIcon(
            icon.Handle,
            new Int32Rect(0, 0, icon.Width, icon.Height),
            BitmapSizeOptions.FromEmptyOptions());
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        using (var ico = System.Drawing.Icon.ExtractAssociatedIcon(@"C:\WINDOWS\system32\notepad.exe"))
        {
            image1.Source = IconToImageSource(ico);
        }
    }
