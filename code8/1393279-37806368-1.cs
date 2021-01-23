    using (var serverMgr = new ServerManager())
    {
        if (IsWebsiteExists(serverMgr, sitename))
        {
            var site = serverMgr.Sites.SingleOrDefault(x => x.Name == sitename);
            if (site != null)
            {
                logger.Trace($"Stopping site '{sitename}'...");
                site.Stop();
                logger.Trace($"Deleting bindings collection for '{sitename}'...");
                site.Bindings.Delete(); // <-- deleting bindings config section itself
            }
            serverMgr.CommitChanges();
        }
    }
