    public partial class Book
    {
        public string ISBN {get; set;}
        public IDictionary<string, object> DynamicProperties { get; set; }
    }
    
    // This portion can be put in a function and can be invoked only once 
    container.Configurations.RequestPipeline.OnEntryStarting(args =>
    {
       if(args.Entity.GetType() == typeof(Book))
       {
          var book = args.Entity as Book
          foreach (var property in book.DynamicProperties)
          {
             args.Entry.AddProperties(new ODataProperty
             {
               Name = property.Key,
               Value = property.Value
             });
          }
        }
     });
