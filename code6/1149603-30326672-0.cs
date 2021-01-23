    public static IEnumerable<int> PrimeNumbers(int Y)
    {
        yield return 2;
        for (int i = 3; i < Y; i = i + 2)
        {
            bool b = false;
            System.Threading.Tasks.Parallel.For(2, i, (o, u) =>
            {
                if (i % o == 0)
                {
                    b = true;
                    u.Break();
                }
            });
            if (b == false)
            {
                yield return i;
            }
        }
    }
