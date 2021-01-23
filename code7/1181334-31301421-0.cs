    public struct Optional<T>
    {
      private readonly bool hasValue;
      private readonly T value;
      public Optional() { }
      public Optional(T value) {
        this.hasValue = true;
        this.value = value;
      }
      public bool HasValue {
        get { return hasValue; }
      }
      public T Value {
        get {
          if (!hasValue)
            throw new InvalidOperationException();
          return value;
        }
      }
      public T GetValueOrDefault() {
        return value;
      }
      public T GetValueOrDefault(T @default) {
        return hasValue ? value : @default;
      }
    }
