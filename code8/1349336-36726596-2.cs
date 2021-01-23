    static void Main(string[] args)
    {
        ILog log = LogManager.GetLogger("Entities");
        using(var scope = new TransactionScope())
        {
           using(var ctx = new Entities())
           {
               try
               {
                   ...
                   ctx.SaveChanges();
                   ... more changes ...
                   ctx.SaveChange();
                   ...
                   scope.Complete();
               }
               catch(Exception ex)
               {
                   log.Error(ex.Message);
               }
           }
        }
    }
