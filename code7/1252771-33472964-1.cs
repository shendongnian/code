    DataTable dtexcel = new DataTable();
    
                using (OleDbConnection conn = new OleDbConnection(strCS))
                {
                    conn.Open();
    
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
    
                    //Looping a first Sheet of Xl File
                    DataRow schemaRow = schemaTable.Rows[0];
                    string sheet = schemaRow["TABLE_NAME"].ToString();
    
                    if (!sheet.EndsWith("_"))
                    {
                        string query = "SELECT  * FROM [" + sheet + "]";
                        OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                        dtexcel.Locale = CultureInfo.CurrentCulture;
                        daexcel.Fill(dtexcel);
                    }
                }
    
                using (SqlConnection sqlconn = new SqlConnection(strCon))
                {
                    SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                    sqlconn.Open();
                    sqlcmd.ExecuteNonQuery();
                }
    
    
                using (SqlConnection sqlconn = new SqlConnection(strCon))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlconn))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = strSqlTable;
    
                        sqlconn.Open();
    
                        sqlBulkCopy.WriteToServer(dtexcel);
    
                    }
                }
