    public void readCSVAutomatic(string pathLocalSuccess, string pathHistory, string pathLogFolderSuccess, string pathErrorLog, string modul)
        {
            try
            {
                string[] files = Directory.GetFiles(pathLocalSuccess);
                foreach (string file in files)
                {
                    FileInfo fileInf = new FileInfo(file);
                    string filename = fileInf.Name;
                    StreamReader reader = new StreamReader(file);
                    string line = reader.ReadLine();
                    string[] value = line.Split('|');
                    DataTable dt = new DataTable();
                    DataRow row;
                    foreach (string dc in value)
                    {
                        dt.Columns.Add(new DataColumn(dc));
                    }
                    while (!reader.EndOfStream)
                    {
                        //value = value.
                        value = reader.ReadLine().Split('|');
                        if (value.Length == dt.Columns.Count)
                        {
                            row = dt.NewRow();
                            row.ItemArray = value;
                            dt.Rows.Add(row);
                        }
                    }
                    string xTableName = dt.Rows[0].ItemArray[0].ToString();
                    string xPeriode = dt.Rows[0].ItemArray[1].ToString();
                    dt.Columns.RemoveAt(0);
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=" + serverDB + "; Initial Catalog=" + DB + "; Trusted_Connection=" + trustedConnection + "; user=" + UserDB + "; password=" + PassDB + "";
                    
                    con.Open();
                    SqlCommand com = con.CreateCommand();
                    string strDelete = "DELETE FROM " + xTableName + " WHERE PERIODE='" + xPeriode + "'";
                    com.CommandText = strDelete;
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
                    bc.DestinationTableName = xTableName;
                    bc.BatchSize = dt.Rows.Count;
                    bc.WriteToServer(dt);
                    bc.Close();
                    con.Close();
                    reader.Close();
                    moveFileAfterImported(pathLocalSuccess, filename, pathHistory);
                    createLogCSVSuccessImported(pathLogFolderSuccess, "File Imported","Message");
                }
            }
            catch(Exception ex)
            {
                createErrorLogImportCSV(pathErrorLog, "ErrorImportCSV", ex.ToString());
            }
        }
