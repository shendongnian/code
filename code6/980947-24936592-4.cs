    public static class Sizer<T>
    {
        static Dictionary<int, T[]> _cache = new Dictionary<int, T[]>();
        public static void Init(ref List<T> list, int size)
        {
            T[] ret;
            if (!_cache.TryGetValue(size, out ret))
            {
                ret = Enumerable.Repeat(default(T), size).ToArray();
                _cache[size] = ret;
            }
            list = ret.ToList();
        }
    }
