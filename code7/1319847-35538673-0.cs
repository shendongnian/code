    public class User : IEquatable<User>
    {
       public int Id {get; set;}
       ...
       public bool Equals(Person other)
       {
          return this.Id == other.Id;
       }
    }
