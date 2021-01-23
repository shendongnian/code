    using (var transaction = dbConnection.BeginTransaction())
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            var entry = dt.Rows[i].Field<uint>("Entry");
            var name = dt.Rows[i].Field<string>("Name");
            var zone = dt.Rows[i].Field<uint>("Zone");
            var type = dt.Rows[i].Field<object>("Type");
            using (var cmd = new MySqlCommand())
            {
                cmd.Parameters.Add("@Entry", MySqlDbType.UInt32).Value = entry;
                cmd.Parameters.Add("@Name", MySqlDbType.VarString);
                cmd.Parameters.Add("@Type", MySqlDbType.Blob).Value=type; //choose the type correctly
                string dataTableName = "zone_" + zone;
                cmd.CommandText = @"INSERT INTO [{dataTableName}] " +
                                  "([entry], [name], [type]) " +
                                  "VALUES (@Entry, @Name, @Type)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = dbConnection; 
                cmd.ExecuteNonQuery();
            }
        }                      
        transaction.Commit();
    } 
 
