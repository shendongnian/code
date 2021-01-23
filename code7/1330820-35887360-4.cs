    public interface IOptional
    {
        bool HasBeenSet { get; }
    }
    public struct Optional<T> : IOptional
    {
        internal readonly T Val;
        public Optional(T value)
        {
            Val = value;
            HasBeenSet = true;
        }
        public Optional(Optional<T> value)
        {
            Val = value.Value;
            HasBeenSet = value.HasBeenSet;
        }
        public bool HasBeenSet { get; }
        
        public override bool Equals(object obj)
        {
            return obj.Equals(Val);
        }
        public override int GetHashCode()
        {
            return Val.GetHashCode();
        }
        
        public static implicit operator T(Optional<T> optional)
        {
            return optional.Val;
        }
        public static implicit operator Optional<T>(T optional)
        {
            return new Optional<T>(optional);
        }
        public T Value => Val;
    }
