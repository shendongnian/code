    private int currentXmlLength;
    private void deserializer()
    {
        internal XmlSerializer serializer = new XmlSerializer(typeof(myAPI));
        EventWaitHandle MyEventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        while (!Global.IsShuttingDown)
        {
            MyEventWaitHandle.WaitOne(10);
            string myUrl = "http://" + apiAddress + ":" + apiPort + "/api";
            int len = GetContentLength(myUrl);
            if(len > 0 && len != currentXmlLength)
            {
                XmlReader reader = XmlReader.Create(myUrl);
                //you may consider using https://github.com/tomba/netserializer here
                apiData = (myAPI)serializer.Deserialize(reader);
                updateChannelData();
            }
        }
    }
    private int GetContentLength(string url)
    {
        int ContentLength = -1;
        System.Net.WebRequest req = System.Net.HttpWebRequest.Create(url);
        req.Method = "HEAD";
        using (System.Net.WebResponse resp = req.GetResponse())
        {
            int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength));             
        }
        return ContentLength;
    }
