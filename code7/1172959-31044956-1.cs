    using (DbContextTransaction transaction = context.Database.BeginTransaction())
    {
       try
       {
          foreach (var item in itemList)
          {
             context.MyFirstEntity.Add(item);
             mySecondEntity.MyFirstEntity = item;
             context.MySecondEntity.Add(mySecondEntity);
          }
        
          transaction.Commit();
       }
       catch (Exception e)
       {
          transaction.Rollback();
       } 
    }
