    void DoGrid<T>(GridView gv)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        foreach (GridColumn col in gv.Columns)
        {
            ...
        }
    }
