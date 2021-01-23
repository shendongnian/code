        DataTable dt = new DataTable(); // assuming this is already populated from your SQL Database.
        StringBuilder buildInsert = new StringBuilder();
        string connectionString = @"Provider=VFPOLEDB.1;Data Source=C:\test.dbf";
        OleDbConnection connection = new OleDbConnection(connectionString);
                
        using (OleDbCommand scriptCommand = connection.CreateCommand())
        {
             connection.Open();
             
             foreach(DataRow dr in dt.Rows)
             {
                 string id = dr["ID"].ToString();
                 string name = dr["Name"].ToString();
                 string details = dr["Details"].ToString();
                 string status = Convert.ToBoolean(dr["Status"]) ? ".t." : ".f.";
                 string createDate = "{^" + Convert.ToDateTime(dr["CreateDate"]).ToString("yyyy-MM-dd") + "}";
                 builderInsert.Append("INSERT INTO \"C:\test.dbf\" ([ID], [Name], [Details], [Status], [CreateDate]) VALUES (" + id + ",\"" + name + "\",\"" + details + "\"," + status + "," + createDate + ")" + Environment.NewLine);
             
                 scriptCommand.CommandType = CommandType.StoredProcedure;
                 scriptCommand.CommandText = "ExecScript";
                 scriptCommand.Parameters.Add("myScript", OleDbType.Char).Value = builderInsert;
                 scriptCommand.ExecuteNonQuery();
                 builderInsert = "";
              }
         }
    
