    object[,] toExport = new object[dgView.Rows.Count, dgView.Columns.Count]; 
    for (int row = 0; row < dgView.Rows.Count; row++)
    {
        DataGridViewRow dgRow = dgView.Rows[row];
        for (int column= 0; column < dgRow.Cells.Count; column++)
        {
            toExport[row, column] = dgRow.Cells[row].Value;
        }
    }
    // export in one go instead of looping and accessing Cells each time
    // use Excel.Application.Transpose(array) if needed
    ws.get_Range("A3").set_Value(Type.Missing, toExport);
