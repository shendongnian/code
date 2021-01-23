    Excel.Application _app = new Excel.Application();
    var workbooks = _app.Workbooks;
    workbooks.Open(_filename);
    // OleDb Connection
    using (OleDbConnection conn = new OleDbConnection(connectionOleDb))
                {
                    try
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = String.Format("SELECT * FROM [{0}$]", tableName);
    OleDbDataReader myReader = cmd.ExecuteReader();
                        int i = 0;
                        while (myReader.Read())
                        {
                            //Here I read through all Excel rows
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Error!\n" + E.Message);
                    }
                    finally
                    {
                        conn.Close();
                        
                        workbooks.Close();
                        if (workbooks != null)
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                        _app.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(_app);
                    }
                }
