    private static void Increment(byte[] x)
    {
        for (int i = x.Length - 1; i >= 0; i--)
        {
            if (x[i] != 0xFF)
            {
                x[i]++;
                return;
            }
            x[i] = 0;
        }
    }
