    private void Import_To_GridTest(string FilePath)
            {
                DataTable dt =new DataTable();
            
                try
                {
                    string sSheetName = null;
                    string sConnection = null;
                    DataTable dtTablesList = default(DataTable);
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    OleDbConnection oleExcelConnection = default(OleDbConnection);
                    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Macro;HDR=YES;IMEX=1\"";
                    sConnection = String.Format(sConnection, FilePath);
                    oleExcelConnection = new OleDbConnection(sConnection);
                    oleExcelConnection.Open();
                    dtTablesList = oleExcelConnection.GetSchema("Tables");
                    if (dtTablesList.Rows.Count > 0)
                    {
                        sSheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
                    }
                    dtTablesList.Clear();
                    dtTablesList.Dispose();
    
                    if (!string.IsNullOrEmpty(sSheetName))
                    {
                        var oleExcelCommand = oleExcelConnection.CreateCommand();
                        oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                        oleExcelCommand.CommandType = CommandType.Text;
                        oda.SelectCommand = oleExcelCommand;
                        oda.Fill(dt);
                        oleExcelConnection.Close();
                    }
    
                    oleExcelConnection.Close();
                
                    gridview1.DataSource = dt;
                    gridview1.DataBind();
    
                
    
                }
         
                catch (Exception e)
                {
                    lblMsg.Text = "Unspecified Error Occured..!! <br>" + e.Message;
                    divMsg.Attributes["class"] = "alert alert-danger";
                    mainDiv.Visible = true;
                    File.Delete(FilePath);
    
                }
            }
