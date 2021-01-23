    while (p1s1 != 0)
    {
        n = int.MinValue;
        p2s1 = 0;
        for (int i8 = 0; i8 < p1.Length; i8++)
        {
            if (p1[i8] != int.MaxValue)
            {
                if (p1[i8] >= n)
                {
                    p2[p2s1] = p1[i8];
                    n = p1[i8];
                    p1[i8] = int.MaxValue;
                    p1s1--;
                    p2s1++;
                }
            }
        }
