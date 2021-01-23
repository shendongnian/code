    public class PersistentCustomerService : IPersistenceService
    {
       public IIdentifiableEntity AddSomeEntity(Customer model)
       {
          var result = _context.Customers.Add(model);
          return result;
       }
    }
    
    public class Customer : IIdentifiableEntity
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
