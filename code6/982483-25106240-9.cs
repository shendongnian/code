    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Customer>("Customers");
    builder.EntitySet<Order>("Orders");
    builder.EntitySet<OrderDetail>("OrderDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    //config.AddODataQueryFilter();
    config.AddODataQueryFilter(new SecureAccessAttribute());
