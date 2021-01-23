    public class DataContext : DbContext
    {
      string setElementsTableId; 
      // use the setElementsTableId as extended property of the 
      // connection string to generate a custom key
      public DataContext(string setElementsTableId)
            : base(ConfigurationManager.ConnectionStrings["RepositoryConnectionString"] 
     + "; Extended Properties=\"setElementsTableId=" + setElementsTableId + "\"")
      {
        this.setElementsTableId = setElementsTableId;
      }
      public DbSet<Entities.SetElement> SetElements { get; set; } 
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        if (!string.IsNullOrEmpty(setElementsTableId))
        {
            modelBuilder.Entity<Entities.SetElement>().Map(x => x.ToTable(setElementsTableId)); 
        }
      }
    }
