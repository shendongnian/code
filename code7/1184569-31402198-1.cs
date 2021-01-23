    public partial class EntityName : IName
    {
      // Nothing to do EntityName already defines public string Name { get; set; }
    
      public string FullName { get { return "Person: " +  Name; }}
    }
    
    
    public partial class EntityOrder : IName, IOrder
    {
      // Nothing to do Entity Order already defines public string Name { get; set; }
      // and Amount.
    
      public string FullName { get { return "Order: " + Name; } }
    }
