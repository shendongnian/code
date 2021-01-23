    string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\MyData.xlsx;" +
                          @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Do your things here
                    }
                }
            }
