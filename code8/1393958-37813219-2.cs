    public class MutableInt: IComparable<MutableInt> 
    {
      ...
      public int CompareTo(MutableInt other) 
      {
        return (null == other)
          ? 1
          : _value.CompareTo(other._value);      
      } 
      ...
    }
