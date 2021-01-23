    public static class Lens
    {
        public static V Get<T, V>(this Lens<T, V> lens, T item)
        {
            return lens.Getter(item);
        }
        public static T Set<T, V>(this Lens<T, V> lens, T item, V value)
        {
            return lens.Setter(value, item);
        }
        public static Lens<T, V> Compose<T, U, V>(
            this Lens<T, U> lens1,
            Lens<U, V> lens2)
        {
            return new Lens<T, V>(
                x => lens2.Get(lens1.Get(x)),
                (v, x) => lens1.Set(x, lens2.Set(lens1.Get(x), v)));
        }
    }
