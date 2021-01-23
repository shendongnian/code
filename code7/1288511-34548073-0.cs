    public static void AddNewRow(this DataGridView datagridview, params string[] parameters)
    {
        List<object> values = new List<object>() { " ", " ", "A" };
        values.AddRange(parameters);
        datagridview.Rows.Add(values.ToArray());
    }
