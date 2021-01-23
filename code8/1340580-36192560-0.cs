    class Person{
     ..more properties here
    
      public virtual ICollection<CreditCard> CreditCards{ get; set; }
    }
    
    class CreditCard{
     ..more properties here
    
      public virtual ICollection<Person> Persons{ get; set; }
    }
