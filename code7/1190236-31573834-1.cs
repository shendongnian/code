    DataTable statusTable = new DataTable() ;
    statusTable.AddColumn("Code"   ,system.typeof(Int32)) ;
    statusTable.AddColumn("Caption",system.typeof(String));
    for (int i=0;i<3;i++) 
    {
      DataRow row = statusTable.newRow() ;
      row[0]=i ;
      row[1]=new string[] { "Zero", "One", "Two", "Three" }[i] ;
      statusTable.AddRow(row) ;
    }
