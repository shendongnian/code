    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
             modelBuilder.Entity<Paper>()
                .HasRequired(c => c.ChartOfAccountSale )
                //.WithMany()
                .HasForeignKey(c => c.ChartOfAccountIdSale)
                .WillCascadeOnDelete(false);
             modelBuilder.Entity<Paper>()
                .HasRequired(c => c.ChartOfAccountInventory )
                //.WithMany()
                .HasForeignKey(c => c.ChartOfAccountIdInventory )
                .WillCascadeOnDelete(false);
             modelBuilder.Entity<Paper>()
                .HasRequired(c => c.ChartOfAccountCostOfSale )
                //.WithMany()
                .HasForeignKey(c => c.ChartOfAccountIdCostOfSale )
                .WillCascadeOnDelete(false);
}
