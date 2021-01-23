    public static class Extensions
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Func<T,bool> condition)
        {
            foreach(var item in collection)
            {
                if(condition(item))
                {
                    yield return item;
                }
            }
        }
    
        public static T MyFirst<T>(this IEnumerable<T> collection, Func<T,bool> condition)
        {
            foreach (var item in collection)
            {
                if (condition(item))
                {
                    return item;
                }
            }
    
            throw new InvalidOperationException("No element found");
        }
    }
