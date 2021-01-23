    public static class Extensions
    {
        public static IEnumerable<P> SelectProperty<T, P>(this IEnumerable<T> source, string propertyName)
        {
            var selector = (Func<T, P>)Delegate.CreateDelegate(typeof(Func<T, P>), typeof(T).GetProperty(propertyName).GetGetMethod());
            return source.Select(selector);
        }
    }
