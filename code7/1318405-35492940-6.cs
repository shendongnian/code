    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
      { 
        modelBuilder.Entity&lt;ExpenseIncome&gt;().HasKey(e => e.ID);
        modelBuilder.Entity&lt;ExpenseIncomeType&gt;().HasKey(e => e.ID);
      }
