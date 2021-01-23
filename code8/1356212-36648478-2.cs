     public class YourContext: DbContext 
        {
            public YourDBContext(): base() 
            {
            }
    
            public DbSet<Material> Materials { get; set; }
            public DbSet<ScheduleRow> ScheduleRows { get; set; }
            
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                    //Configure default schema
                modelBuilder.HasDefaultSchema("YourSchema");
                        
                //Map entity to table
                modelBuilder.Entity<Material>().ToTable("Material");
                modelBuilder.Entity<ScheduleRow>().ToTable("RunScheduleRow","dbo");
    
            }
        }
    }
