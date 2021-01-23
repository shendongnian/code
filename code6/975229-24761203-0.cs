    public class MyType : IEquatable<MyType>
    {
      public string a;
      public string b;
      public string c;
      public bool Equals(MyType other)
      {
        if (other == null)
          return false;
        if (GetType() != other.GetType()) // can be omitted if you mark the CLASS as sealed
          return false;
        return a == other.a && b == other.b && c == other.c;
      }
      public override bool Equals(object obj)
      {
        return Equals(obj as MyType);
      }
      public override int GetHashCode()
      {
        int hash = 0;
        if (a != null)
          hash ^= a.GetHashCode();
        if (b != null)
          hash ^= b.GetHashCode();
        if (c != null)
          hash ^= c.GetHashCode();
        return hash;
      }
    }
