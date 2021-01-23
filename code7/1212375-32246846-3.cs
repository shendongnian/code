    public Stream ImageToStream(Image image)
    {
        //Save to stream
        MemoryStream stream = new MemoryStream();
        image.Save(stream, image.RawFormat);
    
        return stream;
    }
