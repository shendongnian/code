    public static object[] ExtractColumn(ResponseRow[] responseRows, int columnIndex)
    {
        if (columnIndex < 0)
        {
            return null;
        }
        object[] objects = new object[responseRows.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            object data = responseRows[i].RowData[columnIndex];
            if(data is DateTime)
                data = ((DateTime)data).Date;
            objects[i] = data;
        }
        return objects;
    }
