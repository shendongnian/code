    using (DbContextTransaction transaction = context.Database.BeginTransaction())
    {
       try
       {
          foreach (var item in itemList)
          {
             context.MyFirstEntity.Add(item);
             context.SaveChanges();
        
             mySecondEntity.MyFirstEntityId = item.Id;
             context.MySecondEntity.Add(mySecondEntity.MyFirstEntityId);
             context.SaveChanges();
          }
        
          transaction.Commit();
       }
       catch (Exception e)
       {
          transaction.Rollback();
       } 
    }
