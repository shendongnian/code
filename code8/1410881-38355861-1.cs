    try
    {
      var s =   myDbContext.Database.ExecuteSqlCommand("myTest44");
      Console.WriteLine(s);
    }
    catch (Exception ex)
    {
       Console.WriteLine(ex);
       throw;
    }
