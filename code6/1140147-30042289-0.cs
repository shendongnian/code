    public static class MyEnumerableExtensions
    {
        public static IEnumerable<T> OrEmpty(this IEnumerable<T> self)
        {
            return self ?? Enumerable.Empty<T>();
        }
    }
    var numbersAndWords = numbers.OrEmpty()
        .Zip(words.OrEmpty(), (n, w) => new { Number = n, Word = w });
