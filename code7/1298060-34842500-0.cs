    public DataTable GetDataTable<T>(List<T> list) where T : class
    {
       DataTable table = new DataTable();
       var fields = typeof(T).GetFields();
       //Create Columns
       foreach(var field in fields)
       {
          DataColumn c = new DataColumn(field.Name, field.GetType());
          c.AllowDbNull = true;
          table.Columns.Add(c);
       }
       //Create rows
       foreach(T record in list)
       {
          DataRow row = table.NewRow();
          
          foreach(var field in fields)
          {
             //If it's null the cell will contain DbNull.Value
             if(field.GetValue(record) != null)
                row[field.Name] = field.GetValue(record);
          }
        
          table.Rows.Add(row);
       }
       return table;
    }
