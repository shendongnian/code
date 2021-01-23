    int total = 0;
    int rowstart = 4;
    while (ws.Cells[rowstart, 1].Value.ToString() != "")
    {
    int val=0;
    if (ws.Cells[rowstart, 1].Value.ToString() != ws.Cells[rowstart + 1, 1].Value.ToString())
    {
       ws.InsertRow(rowstart + 1, 1);
       ws.Cells[rowstart + 1, 3].Value = total;
    }
    else
    { 
    int.TryParse(ws.Cells[rowstart, 3].Value.ToString(), out val);
        total = total + val; 
       // I'm adding the value of Column 3 to the variable total, I get the error if the cell is empty
       rowstart = rowstart + 1;
    }
    
    }
