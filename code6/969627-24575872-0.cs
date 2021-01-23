    var wc = new WebClient();
    var buf = wc.UploadData("http://......./test", new byte[] { 71, 72, 73, 74, 75 });
---
    [OperationContract]
    [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
    public string testSaveFile(Stream img)
    {
        string filename = ".......";
        Console.WriteLine("stream received");
        using (var f = File.OpenWrite(filename))
        {
            img.CopyTo(f);
        }
        Console.WriteLine("stream size: " + new FileInfo(filename).Length);
        return "OK";
    }
