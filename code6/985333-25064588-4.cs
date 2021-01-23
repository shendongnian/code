    public class ClassA : IEquatable<ClassA>
    {
      private int _value;
      public bool Equals(ClassA other)
      {
        return _value == other._value;
      }
    }
