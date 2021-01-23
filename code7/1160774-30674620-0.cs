    class ContextFactory
    {
      public Context Create(string userName, string Password)
      {
      //creating context
      }
    }
    
    class SomeClass
    {
      private ContextFactory _factory;
      public SomeClass(ContextFactory factory)
      {
        _factory = factory;
      }
    
      public IQueryable<Customers> ListCustomersByName(Username user, Password password, string firstName)
      {
          var context = _factory.Create(user, password);
          return customers.Where(c => c.FirstName == firstName);
      }
    }
    
    public static void Main()
    {
      //creating container and register dependency
      var container = new UnityContainer();
      container.RegisterType<ContextFactory>();
    
      var someClass = container.Resolve<SomeClass>();
    
      var customers = someClass.ListCustomersByName(username, password, firstName);
        //... Use this list to do anything
    }
