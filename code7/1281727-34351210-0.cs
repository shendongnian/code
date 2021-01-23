    public partial class MyDatabaseEntities : DbContext
    {
    public MyDatabaseEntities(string connectionString)
        : base(connectionString)
    {
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }
    public virtual DbSet<MyTable> MyTable { get; set; }
