    RouteEntry IDirectRouteFactory.CreateRoute(DirectRouteFactoryContext context)
    {
        Contract.Assert(context != null);
        IDirectRouteBuilder builder = context.CreateBuilder(Template);
        Contract.Assert(builder != null);
        builder.Name = Name;
        builder.Order = Order;
        return builder.Build();
    }
