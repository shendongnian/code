    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    foreach (ImageCodecInfo codec in codecs)
    {
        if (codec.FormatID == ImageFormat.Jpeg.Guid)
        {
            var myEncoder = System.Drawing.Imaging.Encoder.Quality;
            var myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            var myEncoderParameters = new EncoderParameters(1) { Param = { [0] = myEncoderParameter } };
            newBmp.Save(@"C:\qqq\111.jpeg", codec, myEncoderParameters);
            break;
        }
    }
