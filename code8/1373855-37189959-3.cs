    static IEnumerable<int> FibonacciByLength(int length)
    {
        int a = 1;
        int b = 0;
        for (int i = 1; i <= length; i++)
        {
            int c = a + b;
            a = b;
            b = c;
            yield return c;
        }
    }
