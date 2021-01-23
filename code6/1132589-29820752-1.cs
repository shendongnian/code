    public static int size(int[] S, int n)
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += S[i];
        }
        return sum;
    }
