    using (var transaction = ctx.Database.BeginTransaction())
    {
       int i = 0;
       foreach(var concept in concepts)
       {
          ctx.Concepts.Add(concept);
          i++;
          if (i >= 1000)
          {
             i = 0;
             ctx.SaveChanges();
          }
       }
       ctx.SaveChanges()
       transaction.Commit();
    }
          
