    public class Room {
         public string Name;
         public string Foo;
    
         public override bool Equals(object obj)
         {
             NestedC other = obj as NestedC;
             if (other == null) return false;
             return this.Name == other.Name && this.Foo == other.Foo;
         }
    
         public override int GetHashCode()
         {
             return (Name.GetHashCode() ^ Foo.GetHashCode()).GetHashCode();
         }
    }
