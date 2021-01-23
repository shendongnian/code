    public static int[] Make2(int[] a, int[] b)
    {
        int[] result = new int[2];
        int i = 0;
        for (int ai = 0; i < result.Length && ai < a.Length; i++, ai++)
        {
            result[i] = a[ai];
            Console.Write(result[i]);
        }
        for (int bi = 0; i < result.Length && bi < b.Length; i++, bi++)
        {
            result[i] = b[bi];
            Console.Write(result[i]);
        }
        
        Console.WriteLine();
        return result;
    }
