    using (var connection = new SqlConnection(connectionString))
    {
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "Select * from tblTemp";
        connection.Open();
    
        using(SqlDataReader reader = command.ExecuteReader())
        {
            var tableName = "tblTemp";
            var fileName = tableName + ".txt";
            var recordCount = 0;
            var fileCount = 0;
    
            StreamWriter writer = null;
            try
            {
                while (reader.Read())
                {
                    if (writer == null || recordCount == 500000)
                    {
                        recordCount = 0;
    
                        // Close the previous file if it is open...
                        if (writer != null)
                        {
                            writer.Close();
                            writer.Dispose();
                        }
    
                        fileName = tableName + "_" + (++fileCount).ToString() + ".txt";
    
                        // Open the new file...
                        writer = new StreamWriter(fileName);
                    }
    
                    recordCount++;
                    writer.WriterLine(recordInfo); // recordInfo is sudo code as well
                }
            }
            finally
            {
                // Make sure the file gets closed...
                if (writer != null)
                {
                    writer.Dispose();
                }
            }
        }
    }
