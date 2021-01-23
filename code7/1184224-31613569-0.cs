    public partial class Person
    {
        public IDictionary<string, object> DynamicProperties { get; set; }
    }
    
    // This portion can be put in a function and can be invoked only once 
    container.Configurations.RequestPipeline.OnEntryStarting(args =>
    {
       if(args.Entity.GetType() == typeof(Person))
       {
          var person = args.Entity as Person
          foreach (var property in person.DynamicProperties)
          {
             args.Entry.AddProperties(new ODataProperty
             {
               Name = property.Key,
               Value = property.Value
             });
          }
        }
     });
     
     container.AddToEntities(entity);
     container.SaveChanges();
