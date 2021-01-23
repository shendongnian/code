          public static DataSet ToDateSet(IDataReader reader)
            {
                var ds = new DataSet();
    
                do
                {
    
                    var schema = reader.GetSchemaTable();
                    var dt = new DataTable(schema.TableName);
    
                    for (var columnIndex = 0; columnIndex < reader.FieldCount; columnIndex++)
                    {
                        dt.Columns.Add(new DataColumn(schema.Rows[columnIndex][0].ToString(), (Type)schema.Rows[columnIndex][2]));
                    }
    
                    while (reader.Read())
                    {
                        var values = new object[reader.FieldCount];
    
                        reader.GetValues(values);
    
                        dt.Rows.Add(values);
                    }
    
                    ds.Tables.Add(dt);
    
                } while (reader.NextResult());
    
                return ds;
            }
    
    public IDataReader ExecuteReader(string connectionString,string cmdText,CommandType cmdType) { 
      
    	  var  con = new SqlConnection(connectionString);
          var  cmd = new SqlCommand(conn,sqlcmd);
          
            cmd.CommandType = cmdType; 
            con.Open();
    
         return cmd.ExecuteReader();    
    }
    
    private void DoSMSSender() { 
    var reader=ExecuteReader(objCon.getConnectionString(),"EXEC sp_GetSmsSenders",CommandType.StoredProcedure);
    var ds=ToDateSet(reader);
    
            GridView1.DataSource = ds.Tables[0];
    
    }
