    public static class MyEnumerable
    {
        public static IEnumerable<int> Range(int start, int stop)
        {
            for (int i = start; i < stop; i++)
                yield return i;
        }
    }
