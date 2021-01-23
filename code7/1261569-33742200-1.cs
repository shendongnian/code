    public static void Sort(double[,] n)
    {
        for (int i = 0; i < n.GetLength(0) - 1; i++)
        {
            for (int j = i; j < n.GetLength(0); j++)
            {
                if (n[i, 0] > n[j, 0]) // sort by ascending by first index of each row
                {
                    for (int k = 0; k < n.GetLength(1); k++)
                    {
                        var temp = n[i, k];
                        n[i, k] = n[j, k];
                        n[j, k] = temp;
                    }
                }
            }
        }
    }
