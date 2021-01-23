    public static byte[] DownloadFile(ClientContext ctx,string fileUrl)
    {
       var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, fileUrl);
        using (var ms = new MemoryStream())
        {
            fileInfo.Stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
    
