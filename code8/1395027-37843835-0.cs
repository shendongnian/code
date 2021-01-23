    public static class Extensions
    {
        public static IEnumerable<Item> Load(this IEnumerable<Item> items)
        {
            foreach(var item in items)
            {
                item.Load()
                
                yield return item;
            }
        }
    }
