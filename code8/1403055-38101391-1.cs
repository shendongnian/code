    using (var dbContext = new MyDatabaseContext(productionConnectionString))
    {
      // You need this for fixup
      var contract1 = dbContext.Contracts.Create<Contract>();
      var contract2 = dbContext.Contracts.Create<Contract>();
      dbContext.Contracts.Add(contract1);
      dbContext.Contracts.Add(contract2);
      contract1.Contracts.Add(contract2);
      dbContext.SaveChanges();
