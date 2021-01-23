    public static T NthOrDefault<T>(this IEnumerable<T> list, int n)
    {
        IEnumerator<T> i = list.GetEnumerator();
        for (int x = 0; x < n; x++)
        {
            if (!i.MoveNext())
            {
                break;
            }
        }
        return i.Current;
    }
