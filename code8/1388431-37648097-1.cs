    grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
    for (int i = 0; i < grid.RowCount; i++)
    {
        grid.Rows[i].HeaderCell = new CustomHeaderCell();
        grid.Rows[i].HeaderCell.Value = string.Format("{0}", i+1);
    }
