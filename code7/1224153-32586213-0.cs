    Table table = new Table();
    table.ID = "Table1";
    
    foreach (Layer l in Layers)
        {
        string splitURL = l.URL.Split('/')[7];
    
        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        TextBox tb = new TextBox();
        tb.ID = splitURL;
        // Add the control to the TableCell
        cell.Controls.Add(tb);
        // Add the TableCell to the TableRow
        row.Cells.Add(cell);
        table.Rows.Add(row);
        }
    mapInnerDiv.Controls.Add(table);
