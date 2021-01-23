    public static class InfEx
    {
        public static IEnumerable<T> LoopForever<T>(this IEnumerable<T> src)
        {
            var data = src.ToList();
            for(;;)
            {
                foreach(var item in data)
                {
                    yield return item;
                }
            }
        }
    }
