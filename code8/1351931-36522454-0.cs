    try
    {
        reader = ZipReader.Open(stream);
        moreFiles = reader.MoveToNextEntry();
    }
    catch (CryptographicException e) when (e.Message == "No password supplied for encrypted zip.")
    {
        stream.Seek(0, SeekOrigin.Begin);
        reader = ZipReader.Open(stream, pwd);
        moreFiles = reader.MoveToNextEntry();
    }
