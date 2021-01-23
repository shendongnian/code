    public class MysqlContext: DbContext
    {
        public DbSet<Test> Test { get; set; }
    
        public MysqlContext(): base("MysqlDefaultConnection")
        {
          
        }
    }
    
    [Table("test")]
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public void Main()
    {
      var myContext = new MysqlContext();
      var t = new Test { Name = "test", Id = 0 };    
      myContext.Set<Test>.Add(t);
      myContext.SaveChanges();
    }
