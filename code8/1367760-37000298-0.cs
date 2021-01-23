    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                
                //inhertance table per type 
                modelBuilder.Entity<Reponse>().ToTable("Organisation");
                modelBuilder.Entity<ReponseChoix>().ToTable("Subtype1");
                modelBuilder.Entity<ReponseSimple>().ToTable("Subtype2");
    
    
            }
