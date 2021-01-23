     string filename = "";
     fileFullPath = FolderPath+"\\"+file.Name;                    
     filename = file.Name.Replace(".xlsx","");                    
     string ConStr;
     string HDR;
     HDR="YES";
     ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +  
               fileFullPath + ";Extended Properties=\"Excel 12.0;HDR=" + 
               HDR + ";IMEX=1\"";  
     OleDbConnection cnn = new OleDbConnection(ConStr);
     cnn.Open();
     DataTable dtSheet = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,  
                         null);  
     string sheetname;
     sheetname="";
     foreach (DataRow drSheet in dtSheet.Rows)
        {
           if (drSheet["TABLE_NAME"].ToString().Contains("$"))
             {
                 sheetname=drSheet["TABLE_NAME"].ToString();
                 OleDbCommand oconn = new OleDbCommand("select * from [" +  
                                      sheetname + "]", cnn);
                 OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                 DataTable dt = new DataTable();
                 adp.Fill(dt);
                 string tableDDL = "";
                 tableDDL += "IF Not EXISTS (SELECT * FROM sys.objects WHERE 
                              object_id = ";
                  tableDDL +="OBJECT_ID(N'[dbo].[" + filename +"]') AND  
                              type  in (N'U'))";
                   tableDDL +=  "Create table [" + filename + "]";
                   tableDDL += "(";
                     for (int i = 0; i < dt.Columns.Count; i++)
                     {
                      if (i != dt.Columns.Count - 1)
                         tableDDL += "[" + dt.Columns[i].ColumnName + "] "  
                                  +   "NVarchar(max)" + ",";
                         else
                          tableDDL += "[" + dt.Columns[i].ColumnName + "] "  
                                          + "NVarchar(max)";
                       }
                      tableDDL += ")";
                     SqlConnection myADONETConnection = new SqlConnection();
                     myADONETConnection = (SqlConnection)  
                     (Dts.Connections["Connection 
                      Manager"].AcquireConnection(Dts.Transaction) as 
                               SqlConnection);
                     SqlCommand myCommand = new SqlCommand(tableDDL,  
                      myADONETConnection);
                     myCommand.ExecuteNonQuery();
                     
                     //Load the data from DataTable to SQL Server Table.
                     SqlBulkCopy blk = new SqlBulkCopy(myADONETConnection);
                     blk.DestinationTableName = "[" + filename +"]";
                     blk.WriteToServer(dt);
                } 
            }
}
