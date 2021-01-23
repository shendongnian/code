    using (var client = new WebClient())
    {
        client.Encoding = System.Text.Encoding.UTF8;
        client.DownloadFile("http://example.com/my.xml", "my.xml");
    }
