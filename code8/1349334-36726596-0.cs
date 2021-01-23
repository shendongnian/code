    static void Main(string[] args)
    {
        ILog log = LogManager.GetLogger("Entities");
        using(var ctx = new Entities())
        {
           using(var transaction = ctx.Database.BeginTransaction())
           {
               try
               {
                   ...
                   ctx.SaveChanges();
                   ... more changes ...
                   ctx.SaveChange();
                   ...
                   transaction.Commit();
               }
               catch(Exception ex)
               {
                   transaction.Rollback();
                   log.Error(ex.Message);
               }
           }
        }
    }
