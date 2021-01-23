    public static void RegisterRoutes(RouteCollection routes)
    {
       //Existing code
       GlobalFilters.Filters.Add(new AuditLoggingFilter());
    }
