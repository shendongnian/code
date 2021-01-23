    using (var db = new MyEntities())
    {
         StringBuilder finalquery = new StringBuilder();
         int i = 0;
         foreach (var acc in myacclist)
         {
           i++;
           //will update my account objects here
           finalquery.Append(stmnt);
           if (1 % 1000 = 0) { db.Database.ExecuteSqlCommand(finalquery.ToString()); }
          }
          db.SaveChanges();
     }
