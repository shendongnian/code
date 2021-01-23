    public static IEnumerable<TResult> Offset<T, TResult>(
        this IEnumerable<T> source, int offset, Func<T,T,TResult> selector)
    {
        // TODO: Shenanigans to validate arguments eagerly
        T[] buffer = new T[offset];
        using (var iterator = source.GetEnumerator())
        {
            for (int i = 0; i < offset && iterator.MoveNext(); i++)
            {
                buffer[i] = iterator.Current;
            }
            int index = 0;
            while (iterator.MoveNext())
            {
                T old = buffer[index];
                T current = iterator.Current;
                yield return selector(old, current);
                buffer[index] = current;
                index = (index + 1) % offset;
            }
        }
    }
