    protected void Application_Start()
    {
      // Register global filter
      GlobalFilters.Filters.Add(new MyActionFilterAttribute());
      RegisterGlobalFilters(GlobalFilters.Filters);
    }
