    public static int[] GetBinaryArray(UInt64 n)
    {
        if (n == 0)
        {
            return new int[2] { 0, 0 };
        }
        var val = (int)Math.Ceiling(Math.Log(n,2));
        if (val == 0)
            val++;
        var arr = new int[val];
        for (int i = val-1, j = 0; i >= 0 && j <= val; i--, j++)
        {
            if ((n & ((UInt64)1 << i)) != 0)
                arr[j] = 1;
            else
                arr[j] = 0;
        }
        return arr;
    }
