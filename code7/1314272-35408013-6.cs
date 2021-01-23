    foreach(var col in GridView4.Columns)
    {
        dt.Columns.Add(col.HeaderText);
    }
    foreach (GridViewRow row in GridView4.Rows)
    {
        dt.Rows.Add();
        for (int i=0; i<row.Cells.Count; i++)
        {
            dt.Rows[dt.Rows.Count - 1][i] = (row.Cells[i].FindControl("lbl") as Label).Text;
        }
    }
