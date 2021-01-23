               // Excel file path
            string excelFilePath = @"F:\Excel File.xlsx";
            // Connection string for accessing excel file
            string connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=""Excel 12.0 Xml;HDR=YES""", excelFilePath);
            using (OleDbConnection Connection = new OleDbConnection(connectionString))
            {
                try
                {
                    Connection.Open();
                    using (OleDbCommand Command = new OleDbCommand())
                    {
                        Command.Connection = Connection;
                        Command.CommandText = "CREATE TABLE [Students] ([First Name] Char(200), [Last Name] Char(200), [Age] Char(2))";
                        Command.ExecuteNonQuery();
                        Console.WriteLine("Table Created Successfully");
                    }
                    Console.ReadLine();
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine("Message: " + ex.Message);
                    Console.ReadLine();
                }
                finally
                {
                    Connection.Close();
                }
            }
