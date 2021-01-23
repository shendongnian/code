    Dictionary<string, Func<CodeTableContext, DbSet>> entityDbSetMap = new Dictionary<string, Func<EFDB, DbSet>>
	{
		{ "ProductEntity", (db) => db.ProductEntities },
		{ "OrderEntity", (db) => db.OrderEntities },
		{ "FooEntity", (db) => db.FooEntities },
		{ "BarEntity", (db) => db.BarEntities },
        // more mappings ......
	}
    
    public IQueryable GetTableNameObject(string EntityName)
    {
		DbSet dbset = entityDbSetMap[entityName](_context);
		return dbset.AsQueryable();
    }
    
