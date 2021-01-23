    public class User : IEquatable<User>
    {
       public int Id {get; set;}
       ...
       public bool Equals(User other)
       {
          return this.Id == other.Id;
       }
       
       public override bool Equals(object other)
       {
          return this.Id == (User)other.Id;
       }
       public override int GetHashcode()
       {
          return this.Id.GetHashCode();
       }
    }
