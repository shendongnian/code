                var excelConnectionString = ConfigurationSettings.GetExcelConnection(fileLocation);
                var dataTable = new DataTable();
                using (var excelConnection = new OleDbConnection(excelConnectionString))
                {
                    excelConnection.Open();
                    var dataAdapter = new OleDbDataAdapter("SELECT * FROM [Users$]", excelConnection);
                    dataAdapter.Fill(dataTable);
                    excelConnection.Close();
                }
                Console.WriteLine("OpenExcelFile: File successfully opened:" + fileLocation);
                return dataTable;
