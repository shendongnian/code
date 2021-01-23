    public Stream ImageToStream(Image image)
    {
        //Save to stream
        MemoryStream stream = new MemoryStream();
        image.Save(stream, ImageFormat.Jpeg);
        stream.Seek(0, SeekOrigin.Begin); //Need to reset position to 0
        return stream;
    }
