    private class TypedBox<T> where T : struct
    {
      public T Value { get; set; }
      public TypedBox(T value)
      {
        Value = value;
      }
    }
