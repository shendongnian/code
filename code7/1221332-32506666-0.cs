    public static int ExecuteByExtension<T>(this TAContainer<T> tAContainer, IDTContainer dataTable) where T : DBAccess, new()
    {
        var ta = (tAContainer as TableAdapter<T>);
        // ...
        return 0;
    }
