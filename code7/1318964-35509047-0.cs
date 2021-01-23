    public class Person : IEquatable<Person>
    {
         public string Id { get; set; }
    
         public override bool Equals(object some) => Equals((Person)some);
         public override bool GetHashCode() => Id != null ? Id.GetHashCode() : 0;
         public bool Equals(Person person) => person != null && person.UniqueId == UniqueId;
    }
