    for (int i = 0; i <10; i++)
    {
        TableRow tr = new TableRow();
    
        TableCell td = new TableCell();
        td.Text = "Value of " + i;
    
        tr.Cells.Add(td);
    
        myTable.Rows.Add(tr);
    
    }
