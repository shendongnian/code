    protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
    
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.BList.AddOrUpdate(
    
              new ClassB { BId = Guid.NewGuid().ToString() },
              new ClassB { BId = Guid.NewGuid().ToString() },
              new ClassB { BId = Guid.NewGuid().ToString() }
            );
            
        }
