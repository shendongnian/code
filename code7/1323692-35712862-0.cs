    public static MemoryStream GetMemoryStreamResult(MagickImageCollection imageGif)
    {
        MemoryStream ms = new MemoryStream();
        imageGif.Write(ms, MagickFormat.Gif);
        ms.Seek(0, SeekOrigin.Begin);
        return ms;
    }
