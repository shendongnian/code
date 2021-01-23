    public partial class MyContext : DbContext
    {
            public MyContext (string nameOrConnectionString)
                : base(nameOrConnectionString)
            {
            }
            ...
    }
