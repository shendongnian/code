    using (Image img = Image.FromFile(@"C:\Temp\BigHead.jpg"))
    {
        // resize img to the height of a PicBox
        Image imageData = ResizeImage2(img, 0, pb2.Height);
        // winforms show img
        pb2.Image = imageData;
    
        // get codec
        ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders()
            .FirstOrDefault(z => z.MimeType == "image/jpeg");
        using (var qparam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100))
        {
            EncoderParameters encParams = new EncoderParameters(1);
            encParams.Param[0] = qparam;
            imageData.Save(@"C:\Temp\BigHead_thumb.jpg", codec, encParams);
        }
        // ToDo: dispose of returned image
    }
