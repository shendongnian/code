    using (var manager = new ServerManager())                
    {
       //Get Site using Website ID
       var site = manager.Sites.SingleOrDefault(m => m.Id == webSiteID);
       if (site != null)
       {
          bld.AppendLine("1. Stopping App Pool for: " + site.Name + " " + targetPath);
          var application = site.Applications.SingleOrDefault(m => m.VirtualDirectories["/"].PhysicalPath == @targetPath);
          var appPoolName = application.ApplicationPoolName;
          var appPool = manager.ApplicationPools[appPoolName];
          if (appPool != null)
          { ...
