     var rowno = 1;//your Row No
        var Colno = 1;//Column no
    long LastRow = xlRange.Rows.Count;
        for (int j = 0; j < lastCols; j++)
            {
                 for (int j = 0; j < lastrowss; j++)
                     {
                      CellValue = Convert.ToString(((Excel.Range)xlSheet.Cells[rows,Colno]).Value2); 
                dr = dtTemp.NewRow();
                dr[0] = Convert.ToDecimal(CellValue);
               dtTemp.Rows.Add(dr); 
               rows++;
             }
        Col++
        }
        Dgsource=dtTemp
