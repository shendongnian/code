    private void InsertData(List<string> columnNames, List<string> theValues)
    {
        
        OleDbConnection connection = null;
        OleDbCommand command = null;
        string connectionString = "";
        string columns = "";
        string values = "";
        try
        {
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtDestination.Text + ";Extended Properties=\"Excel 12.0 Xml; HDR=YES\";";
            using (connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                for (int index = 0; index < columnNames.Count; index++)
                {
                    
                    columns += (index == 0) ? "[" + Regex.Replace(columnNames[index], @"\t|\n|\r", "\"") + "]" : ", [" + Regex.Replace(columnNames[index], @"\t|\n|\r", "\"") + "]";
                    values += (index == 0) ? "'" + Regex.Replace(theValues[index], @"\t|\n|\r", "\"") + "'" : ", '" + Regex.Replace(theValues[index], @"\t|\n|\r", "") + "'";
                }
                using (command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("Insert into [Sheet1$] ({0}) values({1})", columns, values);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            ProcessError(ex);
        }
    } 
