    private static void GetPer(char[] list, int k, int m)
    {
        if (k == m)
        {
            permutations.Add((char[])(list.Clone())); //1. here we add a clone of the value to the list
        }
        else
            for (int i = k; i <= m; i++)
            {
                Swap(ref list[k], ref list[i]);
                GetPer(list, k + 1, m);
                Swap(ref list[k], ref list[i]);
            }
    }
