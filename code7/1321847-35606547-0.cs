    SplitNumber(100, new Interval[]
    {
        new Interval { Min = 0, Max = 11 },
        new Interval { Min = 0, Max = 11 },
        new Interval { Min = 0, Max = 40 },
        new Interval { Min = 0, Max = 40 },
    });
    public static void SplitNumber(int n, Interval[] intervals)
    {
        SplitNumber(n, 0, intervals, "");
    }
    public static void SplitNumber(int n, int k, Interval[] intervals, string s)
    {
        if (n < 0) return;
        if (k >= intervals.Length) { if (n == 0) Console.WriteLine(s); }
        else
            for (int i = intervals[k].Min; i <= intervals[k].Max; i++)
                SplitNumber(n - i, k + 1, intervals, string.Format("{0} {1}", s, i));
    }
