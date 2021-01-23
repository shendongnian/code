    static int i = 1;
    private void CreateDefault()
    {
           DataColumn column = null;
           DataTable table = new DataTable();
                    
           column = new DataColumn();
           var Col1 = column;
           Col1.DataType = System.Type.GetType("System.Int32");
           Col1.DefaultValue = i;
           Col1.Unique = false;
           table.Columns.Add(column);
           i = i + 1;
            
           column = new DataColumn();
           var Col2 = column;
           Col2.DataType = System.Type.GetType("System.String");
           Col2.DefaultValue = "Your String";
           table.Columns.Add(column);
            
           DataRow row = null;
           row = table.NewRow();
            
           table.Rows.Add(row);
     }
