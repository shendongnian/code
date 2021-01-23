    private static DataTable FileToTable(String fileName) {
      DataTable result = new DataTable();
    
      foreach (var line in File.ReadLines(fileName)) {
        DataRow row = result.NewRow();
    
        //TODO: you may want tabulation ('\t') separator as well as space
        String[] items = line.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        // Columns adjusting: you don't need exactly 3 columns  
        for (int i = result.Columns.Count; i < items.Length; ++i) 
          result.Columns.Add(String.Format("COL {0}", i + 1));
    
        row.ItemArray = items;
        result.Rows.Add(row);
      }
    
      return result;
    }
    
    ...
    
    dataGridView3.DataSource = FileToTable(txtFileName);
