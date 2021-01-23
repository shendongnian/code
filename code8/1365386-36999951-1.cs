    public class WhateverRepository
    {
      private IDatabaseContext _dbContext;
      public WhateverRepository(IDatabaseContext databaseContext) 
      {  
        _dbContext = databaseContext;
      }
      public int Count()
      {
        // This is possible because the context exposes collections of objects to us
        return _dbContext.Whatevers.Count(); 
      }
    }
    public WhateverRepository MakeRepositoryWithElements(int elementCount)
    {
      var context = new InMemoryDatabaseContext();
      for (int i = 0; i < elementCount; i++)
      {
        context.Whatevers.Add(new Whatever());
      }
      return new WhateverRepository(context);
    }
