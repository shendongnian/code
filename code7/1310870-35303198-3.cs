    //Custom extensions, that using the path of the image, will provide the
    //DPI (of the image) and the scaled size (PixelWidth and PixelHeight).
    var dpi = ListFrames[0].ImageLocation.DpiOf();
    var scaledSize = ListFrames[0].ImageLocation.ScaledSize();
    
    //Custom extension that loads the first frame.
    var image = ListFrames[0].ImageLocation.SourceFrom();
    
    //Rectangle with the same size of the image. Used within the Xor operation.
    var rectangle = new RectangleGeometry(new Rect(
        new System.Windows.Point(0, 0), 
        new System.Windows.Size(image.PixelWidth, image.PixelHeight)));
    Geometry geometry = Geometry.Empty;
    //Each Stroke is transformed into a Geometry and combined with an Union operation.
    foreach(Stroke stroke in CinemagraphInkCanvas.Strokes)
    {
        geometry = Geometry.Combine(geometry, stroke.GetGeometry(), 
            GeometryCombineMode.Union, null);
    }
    //The rectangle with the same size of the image is combined with all of 
    //the Strokes using the Xor operation, basically it inverts the Geometry.
    geometry = Geometry.Combine(geometry, rectangle, GeometryCombineMode.Xor, null);
