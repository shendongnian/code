    GetObjectResponse response = client.GetObject(request);
    using (Stream responseStream = response.ResponseStream)
    {
        var bytes = ReadStream(responseStream);
        var download = new FileContentResult(bytes, "application/pdf");
        download.FileDownloadName = filename;
        return download;
    }
-------
    public static byte[] ReadStream(Stream responseStream)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
