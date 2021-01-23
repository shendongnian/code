    //UIElement used to hold the BitmapSource to be clipped.
    var clippedImage = new System.Windows.Controls.Image
    {
        Height = image.PixelHeight,
        Width = image.PixelWidth,
        Source = image,
        Clip = geometry
    };
    clippedImage.Measure(scaledSize);
    clippedImage.Arrange(new Rect(scaledSize));
    //Gets the render of the Image element, already clipped.
    var imageRender = clippedImage.GetRender(dpi, scaledSize);
    //Merging with all frames:
    Overlay(imageRender, dpi, true);   
