    DataTable dtable = new DataTable();
    dtable.Columns.Add("Key");
    dtable.Columns.Add("Column2");
    dtable.PrimaryKey = new DataColumn[]{dtable.Columns[0]};
    for (int i = 0; i < 10; i++)
    {
        DataRow newRow = dtable.NewRow();
        dtable.Rows.Add(newRow);
    }
