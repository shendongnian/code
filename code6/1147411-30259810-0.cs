        [__DynamicallyInvokable]
        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }
            foreach (TSource local in source)
            {
                if (predicate(local))
                {
                    return true;
                }
            }
            return false;
        }
