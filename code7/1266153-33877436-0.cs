    public class KeyPair : IEquatable<KeyPair>
    {
      public int Min { get; private set; }
      public int Max { get; private set; }
      public KeyPair(int first, int second)
      {
        if (first < second)
        {
          Min = first;
          Max = second;
        }
        else
        {
          Min = second;
          Max = first;
        }
      }
      public bool Equals(KeyPair other)
      {
        return other != null && other.Min == Min && other.Max == Max;
      }
      public override bool Equals(object other)
      {
        return Equals(other as KeyPair);
      }
      public override int GetHashCode()
      {
        return Max * 31 + Min;
      }
    }
