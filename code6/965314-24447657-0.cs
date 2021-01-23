    public static void TransmitFile(this HttpListenerResponse response, string fileName)
    {
        using (var fileStream = File.OpenRead(filename))
        {
            response.ContentLength64 = fileStream.Length;
            fileStream.CopyTo(response.OutputStream);
        }
    }
