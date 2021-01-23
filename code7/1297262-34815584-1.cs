    public static class Tools
    {
        public static int MyCount(this IEnumerable set)
        {
            if (set == null)
                return 0;
            var enumerator = set.GetEnumerator();
            var cnt = 0;
            while (enumerator.MoveNext())
                cnt++;
            return cnt;
        }
    }
