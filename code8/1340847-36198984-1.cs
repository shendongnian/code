    DataTable dt = new DataTable();
    for (int i = 0; i < dataset.ColumnCount; ++i)
    {
        dt.Columns.Add(new DataColumn(dataset.ColumnNames[i]);
    }
    for (int i = 0; i < dataset.RowCount; ++i)
    {
        var row = dt.NewRow();
        for (int k = 0; k < dataset.ColumnCount; ++k)
        {
            row[dataset.ColumnNames[k]] = dataset[i, k];
        }
        dt.Rows.Add(row);
    }
    myGridView.DataSource = dt;
    myGridView.DataBind();
