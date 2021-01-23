                string strCS = string.Empty; ;
                string strFileType = Path.GetExtension(FileUploadExcel.FileName).ToLower();
                string query = "";
    
    
                using (OleDbConnection conn = new OleDbConnection(strCS))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetname = dt.Rows[0]["Table_Name"].ToString();
                    query = "SELECT * FROM [" + sheetname + "]";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
    
                    string strSqlTable = "TABLENAME";
                    string sclearsql = "delete from " + strSqlTable;
    
                    using (SqlConnection sqlconn = new SqlConnection(strCon))
                    {
                        SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                        sqlconn.Open();
                        sqlcmd.ExecuteNonQuery();
                    }
    
    
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = strSqlTable;
    
                            con.Open();
    
                            sqlBulkCopy.WriteToServer(ds);
    
                        }
                    }
                }
