    //Create a new DataTable.
    DataTable dataTable = new DataTable();
 
    //Add columns to DataTable.
    foreach (TableCell cell in GridView1.HeaderRow.Cells)
    {
        dataTable.Columns.Add(cell.Text);
    }
 
    //Loop through the GridView and copy rows.
    foreach (GridViewRow row in GridView1.Rows)
    {
        dataTable.Rows.Add();
        for (int i = 0; i < row.Cells.Count; i++)
        {
            dataTable.Rows[row.RowIndex][i] = row.Cells[i].Text;
        }
    }
