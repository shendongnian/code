    public class Range<T> where T : IComparable<T>
    {
      public T Minimum { get; set; }
      public T Maximum { get; set; }
      public Range(T minimum, T maximum)
      {
        Minimum = minimum;
        Maximum = maximum;
      }
      public Boolean Contains(T value)
      {
        return (Minimum.CompareTo(value) <= 0) && (Maximum.CompareTo(value) >= 0);
      }
    }
