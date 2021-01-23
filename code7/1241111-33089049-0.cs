    using (Context context = new Context()){
      context.Configuration.LazyLoadingEnabled = false;
      Orders = context.Orders
                      .Include(order => order.Status).ToList();
    }
