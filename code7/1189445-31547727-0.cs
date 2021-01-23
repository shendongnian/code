    public static int[] PushNonZeroToLeft(int[] aiArray)
    {
        var alNew = new List<int>();
        var iZeroCount = 0;
        foreach (int i in aiArray)
            if (i > 0)
                alNew.Add(i);
            else
                iZeroCount++;
        alNew.AddRange(Enumerable.Repeat(0, iZeroCount));
        return alNew.ToArray();
    }
