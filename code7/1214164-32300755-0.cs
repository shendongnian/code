    public class MyContext : DbContext
    {
        //workaround to force sqlserver dll to copy
        private static SqlProviderServices instance = SqlProviderServices.Instance;
    }
