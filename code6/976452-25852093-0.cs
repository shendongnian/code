     private ServerManager mgr = new ServerManager();     
     SiteCollection sites = mgr.Sites;
     int port;
     Int32.TryParse(targetPort, out port);
     string DirectoryPath = targetDirectory.Substring(0, targetDirectory.LastIndexOf("\\"));
     site = sites.Add(targetSite, DirectoryPath, port);
     mgr.CommitChanges();
