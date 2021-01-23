        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
    ...
    if( mimeType.ToLower() == "image/jpeg")
    {
        ImageCodecInfo jpgEncoder = this.GetEncoderInfo("image/jpeg")
        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 80L);
        myEncoderParameters.Param[0] = myEncoderParameter;
        image.Save(systemFilePath, jpgEncoder, myEncoderParameters);
    }
    else
    {
        image.Save(systemFilePath);
    }
