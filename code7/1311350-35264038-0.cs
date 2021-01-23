    SyndicationFeed syndicationFeed = null;
    using (var reader = XmlReader.Create("https://mail.google.com/mail/feed/atom"))
    {
        syndicationFeed = SyndicationFeed.Load(reader);
    }
    if(syndicationFeed != null)
    {
        foreach (SyndicationItem item in syndicationFeed.Items)
        {
            // Do everything you want here by checking properties you need from SyndicationItem item variable.
        }
    }
