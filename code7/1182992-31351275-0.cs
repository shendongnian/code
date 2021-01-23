    public static IEnumerable<T> ToObject<T>(this DataTable table) where T : new()
    {
        if (table == null) throw new ArgumentNullException("table");
        foreach (DataRow row in table.Rows) yield return ToObject<T>(row, false);
    }
