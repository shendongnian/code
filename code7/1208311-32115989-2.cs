    using (var iisManager = ServerManager.OpenRemote(iisServer))
    {
        var site = iisManager.Sites[IisSite];
        var app = site.Applications[0];
    
        var pool = iisManager.ApplicationPools[app.ApplicationPoolName];
    }
