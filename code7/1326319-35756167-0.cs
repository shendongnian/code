            Bitmap bmp = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bmp);
        for (int idx = 0; idx < count; idx++)
            {
                bmp.SelectActiveFrame(FrameDimension.Page, idx);
            g.DrawImage(source, new Rectangle(0,0,source.Width,source.Height), 
             new Rectangle(0,0,bmp.Width,bmp.Height));
                ImageCodecInfo myImageCodecInfo;
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;
                myImageCodecInfo = GetEncoderInfo("image/tiff");
                myEncoder = System.Drawing.Imaging.Encoder.Compression;
                myEncoderParameters = new EncoderParameters(1);
                myEncoderParameter = new EncoderParameter(
                    myEncoder,
                    (long)EncoderValue.CompressionLZW);
                myEncoderParameters.Param[0] = myEncoderParameter;    
                bmp.SaveAdd(byteStream, ImageFormat.Tiff);
            }
    
    
     private static ImageCodecInfo GetEncoderInfo(String mimeType)
            {
                int j;
                ImageCodecInfo[] encoders;
                encoders = ImageCodecInfo.GetImageEncoders();
                for (j = 0; j < encoders.Length; ++j)
                {
                    if (encoders[j].MimeType == mimeType)
                        return encoders[j];
                }
                return null;
            }
