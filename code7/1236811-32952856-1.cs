    private object lockRoles = new object();
    
    public Roles GetRoles
    {
      get 
      {
        object cached = HttpContext.Current.Cache["key"];
        if(cached == null) 
        {
          lock(lockRoles)
          {
            cached = HttpContext.Current.Cache["key"];
            if (cached == null) 
            {
              cached = new GetRolesFromDb(...);
              HttpContext.Current.Cache["key"] = cached; 
            }
          }
        }
        return (Roles)cached;
      }
    }    
    public void ClearRoles()
    {
      HttpContext.Current.Cache.Remove("key");
    }
