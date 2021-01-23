    public static IEnumerable<T> GetAllButFirstAndLast<T>(IEnumerable<T> myEnum)
    {
        T jtem = default(T);
        bool first = true;
        foreach (T item in myEnum.Skip(1)) 
        { 
            if (first) { first = false; } else { yield return jtem; }  
            jtem = item;
        }
    }
