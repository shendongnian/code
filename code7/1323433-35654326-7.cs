    public static void GnomeSort<T>(this List<T> a) where T : IComparable<T>
    {
        IComparer<T> comparer = Comparer<T>.Default;
        int i = 1, j = 2;
        while (i < a.Count)
        {
            if (comparer.Compare(a[i - 1] ,a[i])<1)
            {
                i = j;
                j++;
            }
            else
            {
                T tmp = a[i - 1];
                a[i - 1] = a[i];
                a[i] = tmp;
                i -= 1;
                if (i == 0)
                {
                    i = 1;
                    j = 2;
                }
            }
        }
    }
