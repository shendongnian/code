    public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
    {
      filters.Add(new LogRequest());
    }
    
    protected void Application_Start()
    {
      RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
    }
