    public Stream ImageToStream(Image image)
    {
        //Save to stream
        MemoryStream stream = new MemoryStream();
        image.Save(stream, ImageFormat.Jpeg);
    
        return stream;
    }
