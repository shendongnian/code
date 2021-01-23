    public IEdmModel GetModel(bool includeCustomerOrders)
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    
        var customerType = builder.EntitySet<Customer>("Customers").EntityType;
        if (!includeCustomerOrders)
        {
            customerType.Ignore(c => c.Orders);
        }
        builder.EntitySet<Order>("Orders");
        builder.EntitySet<OrderDetail>("OrderDetails");
        return build.GetModel();
    }
