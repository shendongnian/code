    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    public static Bitmap Resize(Bitmap bmp, int newWidth, int newHeight)
    {
        Image<Hsv, Byte> Iimage = new Image<Hsv, byte>(bmp);
        Image<Hsv, Byte> HsvImage = Iimage.Resize(newWidth, newHeight, Inter.Linear);
        return HsvImage.Bitmap;
    }
    public static Bitmap Threshold(Bitmap Image, byte Value)
    {
        Image<Gray, Byte> img = new Image<Gray, Byte>(Image);
        img = img.ThresholdBinary(new Gray(Value), new Gray(255));
        return img.ToBitmap();
    }
