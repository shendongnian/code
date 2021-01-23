    public class MyService : IService
    {
        public MyService(IIndex<String, DbContext> dbContexts)
        {
            var databaseA = dbContexts["databaseA"];
        }
    }
