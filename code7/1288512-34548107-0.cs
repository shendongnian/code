    public static void AddNewRow(this DataGridView datagridview, params string[] parameters)
    {
        datagridview.Rows.Add(new[] { " ", " ", "A" }.Concat(parameters).ToArray());
    }
 
