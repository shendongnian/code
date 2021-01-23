    private void GenerateTable()
    {
        DataTable dt = this.GetData(); //GetData returns your datatable from sql
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                TableCell cell = new TableCell();
                cell.Text = dt.Rows[i][j].ToString();
                row.Cells.Add(cell);
            }
            table.Rows.Add(row); 
        }
    }
