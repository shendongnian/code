    public static void ShellSort<T>(this List<T> source) where T : IComparable<T>
    {
        IComparer<T> comparer = Comparer<T>.Default;
        int j, increment;
        increment = 3;
        while (increment > 0)
        {
            for (int i = 0; i < source.Count; i++)
            {
                j = i;
                var temp = source[i];
                while ((j >= increment) && comparer.Compare(source[j - increment], temp) > 0)
                {
                    source[j] = source[j - increment];
                    j = j - increment;
                }
                source[j] = temp;
            }
            if (increment / 2 != 0)
            {
                increment = increment / 2;
            }
            else if (increment == 1)
            {
                increment = 0;
            }
            else
            {
                increment = 1;
            }
        }
    }
