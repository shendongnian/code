    public class Lens<T, V>
    {
        public Lens(Func<T, V> getter, Func<V, T, T> setter)
        {
            Getter = getter;
            Setter = setter;
        }
        internal Func<T, V> Getter { get; }
        internal Func<V, T, T> Setter { get; }
    }
