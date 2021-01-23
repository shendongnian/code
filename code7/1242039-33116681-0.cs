      string[] colNames = new string[gv.Columns.Count];
      int col = 0;
      foreach(gvvolumns dc in GridView.Columns)
        colNames[col++] = dc.ColumnName;
      char lastColumn = (char)(65 + dtProducts.Columns.Count - 1);
      oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
      oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
      oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment 
            = Excel.XlVAlign.xlVAlignCenter;
