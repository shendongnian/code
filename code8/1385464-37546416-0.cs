         public static MemoryStream ResizeImageFromStream(Stream stream, String nameOfFile, int width, int height)
    {
        try
        {
            Image img;
            double ratio;
		int newWidth;
		int newHeight;		
            Graphics gfx = null;
            img = Image.FromStream(stream);
            Image Photo = new Bitmap(img, width, height);
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo(nameOfFile.Substring(nameOfFile.LastIndexOf(".")).ToLower());
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 87L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream mstr = new MemoryStream();
            gfx = Graphics.FromImage(Photo);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.SmoothingMode = SmoothingMode.HighQuality;
            gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gfx.CompositingQuality = CompositingQuality.HighQuality;
            gfx.DrawImage(img, 0, 0, width, height);
            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters encParams = new EncoderParameters(1);
            encParams.Param[0] = new EncoderParameter(Encoder.Quality, m_imageQuality);
            
            img.Dispose();
            Photo.Save(mstr, info[1],encParams);
            Photo.Dispose();
            return mstr;
            
        }
        catch
        {
            return new MemoryStream();
        }
    }
