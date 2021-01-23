    DataTable dt = GetTable(); //This is the table with A, B, C and D columns....
    string[] columns = new string[] {"A", "B", "D"};
    DataTable newTable;   // This will have only A, B, and D
    newTable = dt.DefaultView.ToTable("tempTableName", false, columns);
    
