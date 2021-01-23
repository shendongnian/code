    public static class Helper
    {
        public static DataTable ToDataTable(this List<Program.Output> list)
        {
            var dt = new DataTable();
    
            // insert enough amount of rows
            var numRows = list.Select(x => x.results.Length).Max();
            for (int i = 0; i < numRows; i++)
                dt.Rows.Add(dt.NewRow());
    
            // process the data
            foreach (var field in list)
            {
                dt.Columns.Add(field.name);
                for (int i = 0; i < numRows; i++)
                    // replacing missing values with empty strings
                    dt.Rows[i][field.name] = i < field.results.Length ? field.results[i] : string.Empty; 
            }
    
            return dt;
        }
    }
