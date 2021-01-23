    public IEnumerable<string> ExpandViewLocations(
          ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
    
          // Swap /Shared/ for /_Shared/
          return viewLocations.Select(f => f.Replace("/Shared/", "/_Shared/"));
    
    }
