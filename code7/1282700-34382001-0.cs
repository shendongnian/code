    public abstract class MainObj
    {
        public int Status { get; set; }
        public string OType { get; set; }
        public DateTime Date { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //base.OnModelCreating(modelBuilder); you dont need this line, it does nothing
    }
