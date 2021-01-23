    public abstract class BaseStaff {
      public int anInt { get; set; }
      public bool aBool { get; set; }
      public abstract bool Equals(BaseStaff anotherStaff);
    }
