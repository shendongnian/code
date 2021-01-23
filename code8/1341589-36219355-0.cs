    grid.DataSource = ds.Tables[0];
    double sum1 = 0;
    for (int i = 0; i < grid.Rows.Count; ++i)
    {
        sum1 += Convert.ToDouble(grid.Rows[i].Cells[13].Value);
    }
