    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {           
                modelBuilder.Entity<Models.Expense>().HasKey(a => a.expenseID);
                modelBuilder.Entity<Models.Expense>().Property(a => a.expenseID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
                base.OnModelCreating(modelBuilder);
            }
