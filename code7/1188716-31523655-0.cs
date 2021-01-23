            var objectContext = new ObjectContext("connectionString");
            var newDbContext1 = new CustomDbContext(objectContext, false);
            var newDbContext2 = new CustomDbContext(objectContext, false);
            newDbContext1.Dispose();
            newDbContext2.Dispose();
            objectContext.Dispose();
