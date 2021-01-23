    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
         using (SPSite site = new SPSite("http://servername:port/"))
         {
              using (SPWeb web = site.OpenWeb())
              {
                   HttpContext.Current = null;
                   site.AllowUnsafeUpdates = true;
                   web.AllowUnsafeUpdates = true;
    
                   var newSite = site.WebApplication.Sites.Add(....);
              }
         }
    });
