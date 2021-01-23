        if (cell.ColumnIndex == 0)Temp1 = Temp1.Replace("<Status>", cell.Text);
        if (cell.ColumnIndex == 1)Temp1 = Temp1.Replace("<NName>", cell.Text); 
        if (cell.ColumnIndex == 2)Temp1 = Temp1.Replace("<Notes>", cell.Text);
    }
    else
    {
         Temp1 = "" ;
    }`
