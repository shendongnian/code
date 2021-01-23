    public static void RegisterRoutes(RouteCollection routes)
    {
      //Existing route definitions goes here
       GlobalFilters.Filters.Add(new LoadMenu());
    }
