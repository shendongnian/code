    public partial class MyEntities : DbContext
    {
        public MyEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
