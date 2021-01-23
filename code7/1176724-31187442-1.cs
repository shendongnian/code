    foreach (DataGridViewRow row in dataGrid.Rows)
    {
        if ((row.Index == -1) || (e.RowIndex == dataGrid.NewRowIndex))
        {
            continue; // disregard row headers and also the new row
        }
        var obj = row.DataBoundItem;
        foreach (DataGridViewColumn col in row.Cells)
        {
             if (col.Index == -1)
             {
                  continue; // disregard column headers
             }
                    
             col.ReadOnly = !obj.CanBeEdited
        }
    }
