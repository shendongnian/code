    public partial class CustomerEntities : DbContext
    {
        protected CustomerEntities(string nameOrConnectionString):base(nameOrConnectionString)
        {         
        }
    }
    public class ReadonlyCustomerEntities : CustomerEntities
    {
        public ReadonlyCustomerEntities ()
            : base("name=ReadonlyCustomerEntities")
        {          
        }
        public override int SaveChanges()
        {
            // Throw if they try to call this
            throw new InvalidOperationException("This context is read-only.");
        }
    }
