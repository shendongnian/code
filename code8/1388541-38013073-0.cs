      public DataSet GetExcelDataTable(string fileName)
        {
            string connectionString = Path.GetExtension(fileName) == "xls" ?
                string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data source={0}; Extended Properties=Excel 8.0;", fileName) :
                string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fileName);
            var conn = new OleDbConnection(connectionString);
            DataTable data = new DataTable();
            DataTable data2 = new DataTable();
            var ds = new DataSet();
                  
            using (var adapter = new OleDbDataAdapter("SELECT TOP 25000 Name, Surname FROM [Sheet1$] ORDER BY Name asc", conn))
            {
                adapter.Fill(data);
            }
   
            using (var adapter = new OleDbDataAdapter("SELECT TOP 25000 Name, Surname FROM [Sheet1$] ORDER BY Name desc", conn))
            {
                adapter.Fill(data2);
            }
 
            if (data.Rows.Count > 0)ds.Tables.Add(data);
            if (data2.Rows.Count > 0) ds.Tables.Add(data2);
            
            return ds;
        }
