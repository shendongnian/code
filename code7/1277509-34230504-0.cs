    public abstract class Account
    {
        // common entity code here
        ...
    }
    
    public class InvoicedAccount : Account {}
    public class NonInvoicedAccount: Account {}
    
    public YourContext : DbContext
    {
        public DbSet<InvoicedAccount> InvoicedAccounts { get; set; }
        public DbSet<NonInvoicedAccount> NonInvoicedAccounts { get; set; }
    
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<InvoicedAccounts>().Map( m =>
            {
                m.MapInheritedProperties();
                m.ToTable( "InvoicedAccountTable" );
            } );
    
            modelBuilder.Entity<NonInvoicedAccounts>().Map( m =>
            {
                m.MapInheritedProperties();
                m.ToTable( "NonInvoicedAccountTable" );
            } );
        }
    }
