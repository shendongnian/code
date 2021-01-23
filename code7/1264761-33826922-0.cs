    int columns, rows;
    if (!int.TryParse(txtColumns.Text, out columns) || !int.TryParse(txtRows.Text, out rows))
    {
        MessageBox.Show("Insert valid numbers for rows and columns");
        return;
    }
    DataTable table = new DataTable();
    for (int c = 1; c <= columns; c++) 
        table.Columns.Add("Column " + c.ToString());
    for (int r = 1; r <= rows; r++)
    {
        DataRow row = table.Rows.Add();
        foreach (DataColumn col in table.Columns)
        {
            string value = string.Format("{0}{1}{2}", IntToLetters(r), r, col.Ordinal + 1);
            row.SetField(col, value);
        }
    }
