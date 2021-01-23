    public partial class MyContext : DbContext
    {
        [InjectionConstructor]
        public MyContext()
            : base("name=MyConnString")
        {
            Database.SetInitializer<MyContext>(null);
        }
    }
