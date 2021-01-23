    private void Overlay(RenderTargetBitmap render, double dpi, bool forAll = false)
    {
        //Gets the selected frames based on the selection of a ListView, 
        //In this case, every frame should be selected.
        var frameList = forAll ? ListFrames : SelectedFrames();
        int count = 0;
        foreach (FrameInfo frame in frameList)
        {
            var image = frame.ImageLocation.SourceFrom();
            var drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(image, new Rect(0, 0, image.Width, image.Height));
                drawingContext.DrawImage(render, new Rect(0, 0, render.Width, render.Height));
            }
            //Converts the Visual (DrawingVisual) into a BitmapSource
            var bmp = new RenderTargetBitmap(image.PixelWidth, image.PixelHeight, dpi, dpi, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            //Creates a BmpBitmapEncoder and adds the BitmapSource to the frames of the encoder
            var encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            //Saves the image into a file using the encoder
            using (Stream stream = File.Create(frame.ImageLocation))
                encoder.Save(stream);
        }
    }
