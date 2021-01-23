    using (var iisManager = new ServerManager)
    {
        Site site = iisManager.Sites[siteName];
        site.Bindings.Clear();
        iisManager.CommitChanges();
        site = iisManager.Sites[siteName];
        iisManager.Sites.Remove(site);
        iisManager.CommitChanges();
    }
