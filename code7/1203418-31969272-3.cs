    lst.Sort((x, y) =>
    {
        int cmp2 = x.Item1.Length.CompareTo(y.Item1.Length);
        if (cmp2 != 0)
        {
            return cmp2;
        }
        int min = Math.Min(x.Item1.Length, y.Item1.Length);
        for (int i = 0; i < min; i++)
        {
            int cmp = x.Item1[i].CompareTo(y.Item1[i]);
            if (cmp != 0)
            {
                return cmp;
            }
        }
        return 0;
    });
