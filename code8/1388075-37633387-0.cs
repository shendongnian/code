    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Properties()
                                .Where(p => p.Name == "Id")
                                .Configure(p => p.IsKey().HasColumnName(p.ClrPropertyInfo.ReflectedType == null ? "Id" : p.ClrPropertyInfo.ReflectedType.Name + "Id"));
    }
    public class Agency
    {
        public int Id { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        public User AgencyCapturedBy { get; set; }
    }
    [ComplexType]
    public class User
    {
        public int Id { get; set; }
    }
