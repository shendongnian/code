    using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Events2"].ConnectionString))
    { using (var command = sqlConn.CreateCommand())
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "spGetEvent";
             command.Parameters.Add("@EventId", SqlDbType.Int).Value = eventSelected;
            using (var reader = command.ExecuteReader())
             {
                 if(reader.Read())
                 {
                     eventName.Text = reader["EventName"].ToString();
                     location.Text = reader["Location"].ToString();
                     city.Text = reader["City"].ToString();
                     state.Text = reader["State"].ToString();
                     description.Text = reader["Description"].ToString();
                 }
             }
        }
    }
