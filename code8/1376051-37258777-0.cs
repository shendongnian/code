    public static bool In<T>(this T obj, IEqualityComparer<T> comparer, params T[] list)
            {
                if (comparer == null)
                    return list.Contains(obj);
                else
                    return list.Contains(obj, comparer);
            }
    
            public static bool In<T>(this T obj, params T[] list)
            {
                return In(obj, null, list);
            }
