    builder.RegisterAssemblyTypes(typeof(PurchaseOrderManager.Service.FooService).Assembly)
        .Where(t => t.Name.EndsWith("Services"))
        .WithParameter("context", new PurchaseOrderManagerContext())
        .AsImplementedInterfaces();
 
