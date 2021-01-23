    public class MyContext : DbContext
    {
        public MyContext : base(/* your connection string name*/) {}
        DbSet<myPOCO> myPOCOs {get; set;}
        //etc...
    }
