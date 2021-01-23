    public static Bitmap Crop(Image myImage)
    {
        Bitmap croppedBitmap = new Bitmap(myImage);
        croppedBitmap = croppedBitmap.Clone(
                        new Rectangle(100,100,myImage.Width - 200,myImage.Height - 200),
                        System.Drawing.Imaging.PixelFormat.DontCare);
        return croppedBitmap;
    }
