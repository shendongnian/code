    using (var context = new AppContext())
    {
        context.People.Add(new Person { Id = 1 });
        context.SaveChanges();
    }
    using (var context = new AppContext())
    {
        context.Sellers.Add(new Seller { Id = 1 });
        context.SaveChanges();
    }
    using (var context = new AppContext())
    {
        // Throws DBUpdateException, Person Id = 2 doesn't exist.
        context.Sellers.Add(new Seller { Id = 2 });
        context.SaveChanges();
    }
