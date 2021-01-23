    public class MyEntities : DbContext
    {
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
	     {
	        modelBuilder.Entity<Leads>().HasRequired(m => m.NamePrefixes).WithMany(m => m.Leads).HasForeignKey(m => m.NamePrefixID);
	     }
    }
