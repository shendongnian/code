        static void Main(string[] args)
        {
            GetMaxArray(new[] { 1, 5, 4 }, new[] { 2, 4, 3 }, new[] { 7, 9, 1 });
        }
        private static void GetMaxArray(params int[][] m)
        {
            var length = m.First().Length;
            var r = new int[length];
            for (var i = 0; i < length; i++)
                r[i] = m.Select(a => a[i]).Max();
        }
