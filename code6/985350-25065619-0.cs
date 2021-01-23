    public static Bitmap RotateImage(Image image, PointF offset, float angle)
    {
        if (image == null)
            throw new ArgumentNullException("image");
    
        //create a new empty bitmap to hold rotated image
        Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
        rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        return rotatedBmp;
    }
