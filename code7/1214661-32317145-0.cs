    public static bool TrySafeGet<T>(IList<T> list, int index, out T value)
    {
        value = default(T);
    
        if (list == null || index < 0 || index >= list.Count)
        {    
            return false;
        }
    
        value = list[index];
        return true;
    }
