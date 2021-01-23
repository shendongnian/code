    public partial class MyContext : DbContext
    {
        public MyContext ()
            : base("name=MyConnectionString")
        {
        }
        ...
    }
