    using (Entities entities = new Entities())
        using (DbContextTransaction scope = entities.Database.BeginTransaction())
        {
            entities.Database.ExecuteSqlCommand("SELECT TOP 1 KeyColumn FROM MyTable)");
            scope.Commit();
        }
