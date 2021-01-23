    private static void _SetupRefreshJob()
    {
       //remove a previous job
       Action remove = HttpContext.Current.Cache["Refresh"] as Action;
       if (remove is Action)
       {
           HttpContext.Current.Cache.Remove("Refresh");
           remove.EndInvoke(null);
       }
       //get the worker
       Action work = () =>
       {
           while (true)
            {
              Thread.Sleep(60000);
              WebClient refresh = new WebClient();
              try
              {
               refresh.UploadString("http://www.websitename.com/", string.Empty);
              }
              catch (Exception ex)
              {
                        //snip...
              }
              finally
              {
                refresh.Dispose();
              }
          }
      };
      work.BeginInvoke(null, null);
      //add this job to the cache
      HttpContext.Current.Cache.Add(
      "Refresh",
      work,
      null,
      Cache.NoAbsoluteExpiration,
      Cache.NoSlidingExpiration,
      CacheItemPriority.Normal,
      (s, o, r) => { _SetupRefreshJob(); }
      );
    }
