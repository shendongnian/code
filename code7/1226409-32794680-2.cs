     private void Button_Click(object sender, RoutedEventArgs e)
        {
            BitmapSource image = Clipboard.GetImage();
            Stream packagedImage = WpfPayload.SaveImage(image, WpfPayload.ImageBmpContentType);
            object element = WpfPayload.LoadElement(packagedImage);
            Para1.Inlines.Add(element as Span);
        }
