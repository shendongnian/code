    FilterProviders.Providers.Clear();
    
    // Your custom filter provider
    FilterProviders.Providers.Add(new GlobalFilterProvider());
    // This provider registers any filters in GlobalFilters.Filters
    FilterProviders.Providers.Add(new System.Web.Mvc.GlobalFilterCollection());
    // This provider registers any FilterAttribute types automatically (such as ActionFilterAttribute)
    FilterProviders.Providers.Insert(new System.Web.Mvc.FilterAttributeFilterCollection());
