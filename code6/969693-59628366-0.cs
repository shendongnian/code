    public static void SetRoundedCorners(Table table)
    {
        int rowCount = table.Rows.Count;
        int colCount = table.Columns.Count;
    
        if (rowCount < 2 || colCount < 2)
            return;
    
        table.Rows[0].Cells[0].RoundedCorner = RoundedCorner.TopLeft;
        table.Rows[0].Cells[colCount - 1].RoundedCorner =  RoundedCorner.TopRight;
        table.Rows[rowCount - 1].Cells[colCount - 1].RoundedCorner =  RoundedCorner.BottomRight;
        table.Rows[rowCount - 1].Cells[0].RoundedCorner =  RoundedCorner.BottomLeft;
    }
