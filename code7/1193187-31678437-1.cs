    void Main()
    {
    	var builder = new ContainerBuilder();
    	builder.RegisterType<BillingStore>();
    	builder.RegisterType<Consumer>().PropertiesAutowired();
    	var container = builder.Build();
    	var consumer = container.Resolve<Consumer>();
        // The BillingStoreFactory property is now populated
        // on the Consumer object you resolved.
    }
    public class BillingStore { }
    
    public class Consumer
    {
      public Func<BillingStore> BillingStoreFactory { get; set; }
    }
