    public async Task<long> GetSomethingFromDbAndSelectSomethingOnServer()
    {
            using(var context = new MyEfDbContext())
            {
                // include the following if you do not need lazy loading and want some more speed
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                var stuff = await myEfDbContext.StuffTable.ToListAsync();                     
                long itemsCount = stuff.Where(someQueryThatCantGoToDb).Count();
                return itemsCount;
            }
    }
