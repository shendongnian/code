    public DataTable GetDatas(string QueryString, string SheetName)
            {
                DataTable dt = new DataTable();
                try
                {
                    System.Data.OleDb.OleDbConnection MyConnection;
                    System.Data.DataSet DtSet;
                    System.Data.OleDb.OleDbDataAdapter MyCommand;
                    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FileName + "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1'");
                    MyCommand = new System.Data.OleDb.OleDbDataAdapter(QueryString, MyConnection);
                    MyCommand.TableMappings.Add("Table", SheetName);
                    DtSet = new System.Data.DataSet();
                    MyCommand.Fill(DtSet);
                    dt = DtSet.Tables[0];
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return dt;
            }
