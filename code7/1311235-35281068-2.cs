    var product = new Product();
    var factory = new DbContextFactory<MyContext>();
    using (var context = _factory.Create())
    {
        var productRepository = new Repository<Product>(context);
        productRepository.AddItem(product);
        
        // And for example
        var orderRepository = new Repository<Order>(context);
        orderRepository.AddItem(order);
        
        // One SaveChanges call!
        context.SaveChanges();
    }
