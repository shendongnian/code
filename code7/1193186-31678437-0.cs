    void Main()
    {
    	var builder = new ContainerBuilder();
    	builder.RegisterType<Func<BillingStore>>().PropertiesAutowired();
    	builder.RegisterType<Consumer>();
    	var container = builder.Build();
    	var consumer = container.Resolve<Consumer>();
        // The BillingStoreFactory property is null here
        // but you want it populated.
    }
    
    public class BillingStore { }
    
    public class Consumer
    {
      public static Func<BillingStore> BillingStoreFactory { get; set; }
    }
