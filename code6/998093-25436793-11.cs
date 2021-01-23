	var builder = new ContainerBuilder();
	
	builder.RegisterType<OrderDetailsService>().As<IOrderDetailsService>();
	builder.RegisterType<OrderService>().As<IOrderService>();
    /* Register Order and OrderDetails to use themselves: */
	builder.RegisterType<Order>().AsSelf();
	builder.RegisterType<OrderDetails>().AsSelf();
	
	var container = builder.Build();
	
    /* Register the container with AutoMapper */
	Mapper.Configuration.ConstructServicesUsing(container.Resolve);
