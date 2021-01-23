    class Customer
    {
       public int CustomerId {get; set;}
       public string Name {get; set;}
       ...
       public IEnumerable<Object> Objects {get; set;}
    }
    class Object
    {
       public int ObjectId {get; set;}
       public int CustomerId {get; set;}
       public string Name {get; set;}
       ...
    }
