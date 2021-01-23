    public sealed class Input<T>
    {
        public T value { get; set; }
        public Input(T v)
        {
            value = v;
        }
        public static implicit operator T(Input<T> d)
        {
            return d.value;
        }
        public static implicit operator Input<T>(T d)
        {
            return new Input<T>(d);
        }
    }
    public sealed class Output<T>
    {
        public T value { get; set; }
        public Output(T v)
        {
            value = v;
        }
        public static implicit operator T(Output<T> d)
        {
            return d.value;
        }
        public static implicit operator Output<T>(T d)
        {
            return new Output<T>(d);
        }
    }
