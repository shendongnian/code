    public static void YourSort<T,U>(this IList<T> collection, Func<T, U> selector) 
        where U : IComparable<U>
    {
        for (int i = 0; i < collection.Count; i++)
        {
            int minst = i;
            for (int j = i + 1; j < collection.Count; j++)
            {
                if (selector(collection[minst]).CompareTo(selector(collection[j])) > 0)
                {
                    minst = j;
                }
            }
            if (i < minst)
            {
                var temp = collection[minst];
                collection[minst] = collection[i];
                collection[i] = temp;
            }
        }
    }
