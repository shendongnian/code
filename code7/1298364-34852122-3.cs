    // Get a bitmap.
    Bitmap bmp1 = new Bitmap(@"c:\TestPhoto.jpg");
    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
    
    // Create an Encoder object based on the GUID
    // for the Quality parameter category.
    System.Drawing.Imaging.Encoder myEncoder =
        System.Drawing.Imaging.Encoder.Quality;
    
    // Create an EncoderParameters object.
    // An EncoderParameters object has an array of EncoderParameter
    // objects. In this case, there is only one
    // EncoderParameter object in the array.
    EncoderParameters myEncoderParameters = new EncoderParameters(1);
    
    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
    myEncoderParameters.Param[0] = myEncoderParameter;
    MemoryStream ms = new MemoryStream();
    bmp1.Save(ms, jpgEncoder, myEncoderParameters); 
    pictureBox.Image = Image.FromStream(ms);
.....
    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
    
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
