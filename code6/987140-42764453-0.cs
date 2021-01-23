        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
        Response.Cache.SetRevalidation(HttpCacheRevalidation.ProxyCaches);
        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.SetNoStore();
        Response.Cache.SetMaxAge(new TimeSpan(0, 0, 30));
        Response.AppendHeader("Pragma", "no-cache");
