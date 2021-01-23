    static void Main(string[] args)
    {
        ILog log = LogManager.GetLogger("Entities");
        using(var ctx = new Entities())
        {
            try
            {
                ...
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
               log.Error(ex.Message);
            }
        }
    }
