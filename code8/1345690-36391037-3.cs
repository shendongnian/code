    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; i < 10000; ++i)
    {
        for (int j = 0; j < 5000; ++j)
        {
            list.Add(rnd.Next());
        }
        // Sort the second half:
        list.Sort(5000, 5000, Comparer<int>.Default);
                
        // Both the lower and upper half are sorted. Merge-join:
        int lhs = 0;
        int rhs = 5000;
        while (list.Count < 15000)
        {
            int l = list[lhs];
            int r = list[rhs];
            if (l < r)
            {
                list.Add(l);
                ++lhs;
            }
            else if (l > r)
            {
                list.Add(r);
                ++rhs;
            }
            else
            {
                while (list.Count < 15000 && list[lhs] == l)
                {
                    list.Add(l);
                    ++lhs;
                }
                while (list.Count < 15000 && list[rhs] == r)
                {
                    list.Add(r);
                    ++rhs;
                }
            }
        }
        list.RemoveRange(0, 10000);
    }
