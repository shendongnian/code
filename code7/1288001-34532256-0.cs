    Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("Hellow"));
    try
    {
        using (var instream = new GZipStream(stream, CompressionMode.Decompress))
        using (var outputStream = new FileStream("currentXML.xml", FileMode.Append, FileAccess.Write))
        {
            instream.CopyTo(outputStream);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
