    IQueryRepository queryRepository = new EntityFrameworkQueryRepository(new YourDbContext()) ;
    var address = queryRepository.GetEntity<Address>(
        p => p.AddressID == 2,
        new AsNoTrackingQueryStrategy(),
        new EagerLoadingQueryStrategy<Address>(
            p => p.Customers));
