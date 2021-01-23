        public partial class MyDb : DbContext
        {
            public MyDb(string connectionString) : base(connectionString)
            //Or hardcode it in:
            public MyDb() : base("datasource=...")
        }
