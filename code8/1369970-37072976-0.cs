    public string funcion<T>(params T[] Items)
    {
        string sResult = string.Empty;
        foreach (T item in Items)
        {
            sResult += item;
        }
        return sResult;
    }
