    DataTable dtable = new DataTable();
    dtable.Columns.Add("Column1");
    dtable.Columns.Add("Column2");
    for (int i = 0; i < 10; i++)
    {
          DataRow newRow = dtable.NewRow();
          dtable.Rows.Add(newRow);
    }
