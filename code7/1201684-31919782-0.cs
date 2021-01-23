    public static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            } return null;
        }
    EncoderParameters ep = new EncoderParameters(1);
    ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)70);
    ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
    
    newBMP.Save(Server.MapPath("~/listingImages/" + date + filename), ici, ep);
