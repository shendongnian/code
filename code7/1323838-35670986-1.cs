        static void Main(string[] args)
        {
            int[,] array2D = new int[,]{
            { 1, 3, 1, 1, 1 },
            { 1, 3, 3, 3, 1 },
            { 1, 1, 2, 1, 1 },
            { 1, 3, 1, 3, 1 },
            { 1, 1, 1, 1, 1 }};
            var resultList = GetNearbyValues(array2D, 2, 2);
        }
        private static List<int> GetNearbyValues(int[,] array2D, int i, int j)
        {
            var values = from x in Enumerable.Range(i - 1, i + 1)
                         from y in Enumerable.Range(j - 1, j + 1)
                         // make sure x and y are all positive
                         where x >= 0 && y >= 0 && (x != i | y != j)
                         select array2D[x, y];
            return values.Cast<int>().ToList();
        }
