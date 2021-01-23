    public static class ListExtension
    {
        public static void Emplace(this IList<S> list, int x, string s)
        {
            list.Add(new S(x, s));
        }
    }
