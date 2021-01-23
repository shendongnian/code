    string url = "http://eu.battle.net/wow/en/feed/news";
    using (XmlReader reader = XmlReader.Create(url))
    {
        SyndicationFeed feed = SyndicationFeed.Load(reader);
        foreach (SyndicationItem item in feed.Items)
        {
            String subject = item.Title.Text;
            String summary = item.Summary.Text;
        }
    }
