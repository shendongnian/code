    public static void Modify<T>(this DataColumn dataColumn, Func<object, T> toModify)
    {
        foreach(DataRow dataRow in dataColumn.Table.Rows)
        {
            dataRow[dataColumn] = toModify(dataRow[dataColumn]);
        }
    }
