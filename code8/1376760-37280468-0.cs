    public static class EnumerableExtensions
    {
        public static IEnumerable<Tuple<T, T>> WithPrevious<T>(this IEnumerable<T> enumerable)
        {
            var previous = default(T);
            using(var enumerator = enumerable.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    yield return Tuple.Create(previous, enumerator.Current);
                    previous = enumerator.Current;
                }
            }
        }
    }
    foreach(var x in new[] {1, 2, 3, 4, 5}.WithPrevious())
    {
        Console.WriteLine(x.Item1 + " " + x.Item2);
    }
