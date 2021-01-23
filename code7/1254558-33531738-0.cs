    var url = "https://www.binsearch.info/fcgi/nzb.fcgi?q=192636313";
    System.Net.ServicePointManager.Expect100Continue = false;
    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "action", "nzb" },
            { "192636313", "checked" }
        };
        byte[] result = client.UploadValues(url, values);
        var resultstring = new StreamReader(new GZipStream(new MemoryStream(result), CompressionMode.Decompress))
                           .ReadToEnd();
    }
