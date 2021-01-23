    public class SuckyHashCode : IEquatable<SuckyHashCode>
    {
      public int Value { get; set; }
      public bool Equals(SuckyHashCode other)
      {
        return other != null && other.Value == Value;
      }
      public override bool Equals(object obj)
      {
        return Equals(obj as SuckyHashCode);
      }
      public override int GetHashCode()
      {
        return 0;
      }
    }
