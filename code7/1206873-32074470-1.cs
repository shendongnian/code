    SiteCollection websites = iisManager.Sites;
    List<Site> orderedSites = websites.OrderBy(x => x.Name).ToList();
    websites.Clear();
    foreach(Site s in orderedSites)
        websites.Add(s);
