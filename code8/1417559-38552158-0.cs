    string conString = "Server=ServerName;Database=DBName;User Id=UserName;Password =********; ";
    string sqlcmd = " INSERT INTO [TestDB].[dbo].[Test] (ID, Name, CreatedDate) "
                  + " OUTPUT inserted.ID, inserted.Name, inserted.CreatedDate "
                  + " SELECT TOP 10 [ID], [Name], [CreatedDate] FROM [TestDB].[dbo].[TempOrig] ";
    
    using (SqlConnection con = new SqlConnection(conString))
    {
        using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
        {
            con.Open();
    
            // fill in the DataTable object
            DataTable dt = new DataTable();
            using (var insertedOutput = cmd.ExecuteReader())
            {
                dt.Load(insertedOutput);
            }
    
    
            // Read from DataTable object and print on the console
            DataRow[] currentRows = dt.Select(null, null);
    
            if (currentRows.Length < 1)
                Console.WriteLine("No Current Rows Found");
            else
            {
                foreach (DataColumn column in dt.Columns)
                    Console.Write("\t{0}", column.ColumnName);
    
                Console.WriteLine("\t");
    
                foreach (DataRow row in currentRows)
                {
                    foreach (DataColumn column in dt.Columns)
                        Console.Write("\t{0}", row[column]);
    
                   Console.WriteLine("\t");
                }
            }
            Console.ReadLine();
        }
    }
