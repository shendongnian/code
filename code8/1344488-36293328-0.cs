    DataTable B = A.Copy();
    
    foreach (DataColumn col in A.Columns) 
    {
         if (col.DataType != typeof(DateTime))
              B.Columns.Remove(col.ColumnName);
    }
    
    foreach (DataRow row in B.Rows) 
    {
        foreach (DataColumn col in N.Columns) 
        {
             row[col.ColumnName] = DateTime.Parse(String.Format("{0}:dd/MM/yyyy",row[col.ColumnName]));
        }
    }
