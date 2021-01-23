    System.Data.OleDb.OleDbConnection newconn = new System.Data.OleDb.OleDbConnection();
            try
            {
                string pathOfFileToCreate = "U:\\Visual Studio 2013\\Projects\\ANN\\FresnoDataCOC102-2.xlsx";
                newconn.ConnectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES"";", pathOfFileToCreate);
                newconn.Open();
                var cmd = newconn.CreateCommand();
                cmd.CommandText = "CREATE TABLE sheet1 (Date1 String/varhcar(100), PanEObserved DOUBLE, PanECalculated DOUBLE)"; //Check how to declare a varchar exactly.
                cmd.ExecuteNonQuery();
                for (int i = 0; i < training; i++) // Sample Data Insert 
                {
                    int day = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1]).Substring(0, 2));
                    int month = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1]).Substring(3, 2));
                    int year = Convert.ToInt32(Convert.ToString(ds.Tables[0].Rows[i][ds.Tables[0].Columns.Count - 1]).Substring(6, 4));
                    DateTime date = new DateTime(year, month, day);
                    String dateAux = date.ToString("dd/MM/yyyy");
                    cmd.CommandText = String.Format("INSERT INTO Sheet1 (Date1, PanEObserved, PanECalculated) VALUES({0},{1},{2})", "#" + dateAux + "#", ds.Tables[0].Rows[i][inputunits], outputs[i]);
                    cmd.ExecuteNonQuery(); // Execute insert query against excel file.
                }
            }
            finally
            {
                conn.Close();
            }
