    static long SumSquares2(int m, int n)
    {
        checked
        {
            long sum = 0;
            for (long i = m; i <= n; ++i)
            {
                sum += i*i;
            }
            return sum;
        }
    }
