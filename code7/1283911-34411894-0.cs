    DataTable dt = new DataTable();
    dt = DataTasks.CreateDataTableFromSQL(strSQL);
    // Loop counter
    int i = 0;
    int[] ranges = new int[6];
    //assuming you have 6 rows
    foreach (DataRow row in dt.Rows)
    {
      ranges[i] = (int)row["Range"];    
      i++;
    }
