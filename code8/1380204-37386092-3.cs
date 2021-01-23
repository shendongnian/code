    int r = 0;
    for (int c = 0; c <= ColumnCount - 1; c++)
    {
    	for (r = 0; r <= RowCount - 1; r++)
    	{
            if (c == 5) { //Change the constant 5 to use the Student_Image column index
    		   DataArray[r, c] = ByteArrayToImage(DGV.Rows[r].Cells[c].Value);
            }
            else {
    		   DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
            }
    	}
    } 
