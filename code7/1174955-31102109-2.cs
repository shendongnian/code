    //Save User
    System.Web.HttpContext.Current.Cache.Insert(
                           "CurrentUser", 
                            User, 
                            null, 
                            System.Web.Caching.Cache.NoAbsoluteExpiration, 
                            new TimeSpan(0,20,0), 
                            System.Web.Caching.CacheItemPriority.Normal, 
                            null);       
    //Get User   
    User user=(User)System.Web.HttpContext.Current.Cache["CurrentUser"];
     
