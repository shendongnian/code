     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>() 
            .Property(c => c.CourseID) 
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); 
     
            modelBuilder.Entity<Manager>().Map(m => 
            { 
                m.MapInheritedProperties(); 
                m.ToTable("Manager"); 
            }); 
     
            modelBuilder.Entity<Customer>().Map(m => 
            { 
               m.MapInheritedProperties(); 
               m.ToTable("Customer"); 
            });
        }
