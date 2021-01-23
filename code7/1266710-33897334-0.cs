    public object Create(IContext context)
    {
        if (context.Kernel.Get<IHttpContext>().User.IsInRole("Admin"))
        {
            return context.Kernel.Get<OrderMemoryRepository>();
        }
        return context.Kernel.Get<OrderSQLRepository>();
    }
