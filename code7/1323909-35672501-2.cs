     public ApplicationUnitOfWork(ApplicationDbContext context)
     {
        dbContext = context;
        Products = new ProductRepository(dbContext);
     }
