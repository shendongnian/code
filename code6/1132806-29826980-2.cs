    public static class InfEx
    {
        public static IEnumerable<T> LoopForever<T>(this IEnumerable<T> src)
        {
            var data = new List<T>();
            foreach(var item in src)
            {
                data.Add(item);
                yield return item;
            }
            for(;;)
            {
                foreach(var item in data)
                {
                    yield return item;
                }
            }
        }
    }
