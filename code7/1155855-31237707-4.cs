    string message = Console.ReadLine();
    using (var memoryStream = new MemoryStream())
    {
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
        {
            streamWriter.Write(message);
        }
        memoryStream.Flush();
        byte size = Convert.ToByte(memoryStream.Length);
        ns.WriteByte(size);
        memoryStream.Seek(0, SeekOrigin.Begin);
        memoryStream.CopyTo(ns);
        ns.Flush();
    }
