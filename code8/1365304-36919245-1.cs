    if (ds.Tables[0].Rows.Count > 0)
    {
        int rowCounts = ds.Tables[0].Rows.Count;
        int atRowx = 0;
        foreach(DataRow row in ds.Tables[0].Rows){
          atRowX ++;
          if(atRowX = rowCounts-1)
            break;
          //Idea is to read two rows at a time. For each difference, either with C1 or C2, two lines are created.
          If(rowCounts % 4 == 0){ //It found a multiple of two differences
            //Clear up your code to keep the C1 and C2 together or else get the logic for reading row 1 and row 4 in here.
            foreach(DataColumn column in ds.Tables[0].Columns){
              if(row[column] != row+1[column]) 
                Console.WriteLine(ds.Tables[0].Column.ColumnName + "\t");
          }else if(rowCounts % 2){ //It strictly found one difference
            foreach(DataColumn column in ds.Tables[0].Columns){
              if(row[column] != row+1[column]) 
                Console.WriteLine(ds.Tables[0].Column.ColumnName + "\t");
          }
        }
        crs.DataHasChanged = ChangeState.True;
    }
