    public class SampleDataContext : DbContext
    
    {
       public DbSet<SampleUser> Users { get; set; }
    }
        
    [Table("Users")]
    public class SampleUser
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Family { get; set; }
      public string Username { get; set; }
      public override string ToString() => $"{Username} : {Name} {Family}";
    }
    
     
