    public async Task<ActionResult> Contact()
    {
        ......
    
        List<RssFeedModel> feeds = new List<RSsFeedModel>();
    
        XmlNodeReader xreader = new XmlNodeReader(xdoc);
        XmlSerializer deserializer = new XmlSerializer(typeof(RssFeedModel));
    
        feeds.Add((RssFeedModel)deserializer.Deserialize(xreader));
    
        xreader.Close();
        xreader.Dispose();
    
        return View(feeds);
    }
