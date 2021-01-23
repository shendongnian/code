      DataTable dt = new DataTable();
    
      dt.Columns.Add("emp_name", typeof(string));
      dt.Columns.Add("gender", typeof(string));
      dt.Columns.Add("Position", typeof(string));
    
      DataRow[] result = dt.Select("Position != null or Position != '' ");
	  foreach (DataRow row in result)
      {
          string position = row.Field<string>(2);
      }
