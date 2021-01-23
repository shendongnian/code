    public static class Extensions
    {
        public static void Add(this List<Tuple<int, int>> list, int x, int y)
        {
            list.Add(new Tuple<int, int>(x, y));
        }
    }
