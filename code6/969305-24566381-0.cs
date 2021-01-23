    int ColumnIndex = 3; //assign the column index which you want to set autosize
    int iWidth = 0; 
    for ( int i = 0 ; i < ListView1.Columns.Count ; i++ )
    {
        if (ColumnIndex == i)  
            continue;
        iWidth += ListView1.Columns[i].Width;  //Calculating all column width
    }
    ListView1.Columns[ColumnIndex].Width = ListView1.Width - iWidth;
