    public class PhoneNumber : IValueObject {
      public string Number {get; set;}
      public string Type {get; set;}
      public virtual Customer {get; set;}
    }
    
    public class Customer : IEntity {
       public ICollection<PhoneNumber> phones {get; private set;} //ew at no encapsulated collection support
       public void SetPhones(params PhoneNumber[] phones) {
           this.phones.Clear();
           this.phones.AddRange(phones);
       }
    }
