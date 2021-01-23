    class Person
    {
      public Address Address {get;set;}
    }
    
    class Person
    {
      public virtual ICollection<Address> Addresses {get;set;}
    }
    
    class Address
    {
     ...
    }
    
    //or
    class Address
    {
     ...
     public virtual ICollection<Person> People {get;set;}
    }
