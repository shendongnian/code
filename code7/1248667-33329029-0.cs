    image = new Bitmap((Bitmap)baseImage.Clone());
    using (MemoryStream imageStream = new MemoryStream())
    {
        // put iimagem in memory stream
        image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Gif);
    
        // create an array of bytes with image length
        byte[] imageContent = new Byte[imageStream.Length];
    
        // reset memory stream
        imageStream.Position = 0;
    
        // load array of bytes with the imagem
        imageStream.Read(imageContent, 0, (int)imageStream.Length);
    
        // change header page "content-type" to "image/jpeg" and print the image.
        Response.ContentType = "image/gif";
        Response.BinaryWrite(imageContent);
    }
