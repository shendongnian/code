    public class Option<T1, T2>
    {
        public Option(T1 value)
        {
            FirstOption = value;
            FirstOptionValid = true;
        }
        public Option(T2 value)
        {
            SecondOption = value;
            SecondOptionValid = true;
        }
        public T1 FirstOption { get; private set; }
        public bool FirstOptionValid { get; private set; }
        public T2 SecondOption { get; private set; }
        public bool SecondOptionValid { get; private set; }
        public static implicit operator Option<T1, T2>(T2 value)
        {
            return new Option<T1, T2>(value);
        }
        public static implicit operator Option<T1, T2>(T1 value)
        {
            return new Option<T1, T2>(value);
        }
    }
