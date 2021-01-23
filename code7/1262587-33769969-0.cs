    using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Events2"].ConnectionString))
    { using (var command = sqlConn.CreateCommand())
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "spGetEvent";
             command.Parameters.Add("@EventId", SqlDbType.Int).Value = eventSelected;
            command.Parameters.Add("@EventName", SqlDbType.NVarChar, 255).Value = eventName;
            command.Parameters.Add("@Location", SqlDbType.NVarChar, 255).Value = location;
            command.Parameters.Add("@City", SqlDbType.NVarChar, 30).Value = city;
            command.Parameters.Add("@State", SqlDbType.NVarChar, 2).Value = state;
            command.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = description;
            using (var reader = command.ExecuteReader())
             {
                 while (reader.Read())
                 {
                     //do whatever you want here
                 }
             }
        }
    }
