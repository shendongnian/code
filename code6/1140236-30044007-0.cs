    public static class MyEnumerable
    {
        public static IEnumerable<TResult> ZipWithDefault<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            bool firstMoveNext, secondMoveNext;
            using (var enum1 = first.GetEnumerator())
            using (var enum2 = second.GetEnumerator())
            {
                while ((firstMoveNext = enum1.MoveNext()) & (secondMoveNext = enum2.MoveNext()))
                    yield return selector(enum1.Current, enum2.Current);
                if (firstMoveNext && !secondMoveNext)
                {
                    yield return selector(enum1.Current, default(TSecond));
                    while (enum1.MoveNext())
                    {
                        yield return selector(enum1.Current, default(TSecond));
                    }
                }
                else if (!firstMoveNext && secondMoveNext)
                {
                    yield return selector(default(TFirst), enum2.Current);
                    while (enum2.MoveNext())
                    {
                        yield return selector(default(TFirst), enum2.Current);
                    }
                }
            }
        }
    }
