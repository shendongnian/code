    //..
    using System.Drawing.Imaging;
    using System.IO;
    //..
    private Image compressImage(string fileName,  int newWidth, int newHeight, 
                                int newQuality)   // set quality to 1-100, eg 50
    {
        using (Image image = Image.FromFile(fileName))
        using (Image memImage= ResizeImage(image, newWidth, newHeight) )
        {
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myImageCodecInfo = GetEncoderInfo("image/jpeg"); 
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, newQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream memStream = new MemoryStream();
            memImage.Save(memStream, myImageCodecInfo, myEncoderParameters);
            Image newImage = Image.FromStream(memStream);
            ImageAttributes imageAttributes = new ImageAttributes();
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(newImage,  new Rectangle(Point.Empty, newImage.Size), 0, 0, 
                  newImage.Width, newImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            return newImage;
        }
    }
    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo ici in encoders)
            if (ici.MimeType == mimeType) return ici;
        return null;
    }
