    public sealed class SafeEnum<T> where T : struct {
    
      public T Value { get; private set; }
    
      public SafeEnum(T value) {
        if (!(value is Enum)) {
          throw new ArgumentException("The type is not an enumeration.");
        }
        if (!Enum.IsDefined(typeof(T), value)) {
          throw new ArgumentException("The value is not defined in the enumeration.");
        }
        Value = value;
      }
    
    }
