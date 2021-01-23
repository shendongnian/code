    public class A : IMappingConfigurator
    {
         public string Name { get; set; }
    
         public void Configure(IMappingConfiguration config)
         {
              config.Map<Foo>(foo => foo.Name);
         } 
    }
