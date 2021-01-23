    public static int[] Make2(int[] a, int[] b)
    {
        int[] result = new int[2];
        for (int i = 0, ai = 0, bi = 0; i < result.Length; i++)
        {
            if (ai < a.Length)
            {
                result[i] = a[ai];
                ai++;
            }
            else if (bi < b.Length)
            {
                result[i] = b[bi];
                bi++;
            }
            else
            {
                break;
            }
            Console.Write(result[i]);
        }
        Console.WriteLine();
        return result;
    }
