     using (SqlDataReader reader = exportCmd.ExecuteReader())
        using (StreamWriter writer = new StreamWriter(exportFilename))
        {
            string Separator = ",";
        
            while (reader.HasRows)
            {
                while(reader.Read())
                {
                    for (int columnCounter = 0; columnCounter < reader.FieldCount; columnCounter++)
                    {
                        if (columnCounter > 0)
                        {
                            writer.Write(Separator);
                        }
        
                        writer.Write(reader.GetValue(columnCounter).ToString());
                    }
        
                    writer.WriteLine(string.Empty);
                }
                    
    
                While(reader.NextResult() && !reader.hasrows)
                {
    // might be a bette way to do this , problem is that one of your result has no rows, then it exits...
                }
     
            }
        
            writer.Dispose();
        }
