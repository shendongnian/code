    public static class MyExtensions
    {
        public static bool AddIfNotNull<T>(this List<T> list, T item)
        {
            bool added = false;
    
            if(item != null)
            {
                list.Add(item);
                added = true;
            }
    
            return added;
        }
    }
