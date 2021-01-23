    // instead of
    using (var work = new MyDbContext())
    {
        var orders = work.Orders.Where(...).ToList();
        foreach (var order in orders)
        {
            // extra queries issued here
            Console.WriteLine(order.Customer.Name);
        }
    }
    
    // consider
    List<Order> orders;
    using (var work = new MyDbContext())
    {
        orders = work.Orders.Where(...).ToList();
    }
    
    foreach (var order in orders)
    {
        // now this line throws an exception, so the developer
        // will go back and add the .Include() statement instead
        // of just silently creating slow code
        Console.WriteLine(order.Customer.Name);
    }
</pre>
