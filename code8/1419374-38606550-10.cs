    public static class MyExtensions
    {
        public static T RandomFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate, 
                                                                                    Random rnd)
        {
            return source.Where(predicate).OrderBy(i => rnd.Next()).First();
        }
    }
