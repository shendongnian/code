    public static class EnumerableExtensions
    {
        public struct CurrentAndPrevious<T>
        {
            public T Current { get; private set; }
            public T Previous { get; private set; }
            public CurrentAndPrevious(T current, T previous) : this()
            {
                Previous = previous;
                Current = current;
            }
        }
        public static IEnumerable<CurrentAndPrevious<T>> WithPrevious<T>(this IEnumerable<T> enumerable)
        {
            var previous = default(T);
            using(var enumerator = enumerable.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    yield return new CurrentAndPrevious<T>(enumerator.Current, previous);
                    previous = enumerator.Current;
                }
            }
        }
    }
    var items = new[] { 1, 2, 3, 4, 5 };
    foreach(var item in items.WithPrevious())
    {
        Console.WriteLine(item.Previous + " " + item.Current);
    }
