    public class ReusableBox<T> where T : struct
    {
        public T Value { get; set; }
        public ReusableBox()
        {
        }
        public ReusableBox(T value)
        {
            this.Value = value;
        }
        public static implicit operator T(ReusableBox<T> box)
        {
            return box.Value;
        }
        public static implicit operator ReusableBox<T>(T value)
        {
            return new ReusableBox<T>(value);
        }
    }
