    string sql = "UPDATE tbSystems SET Systems = @Systems WHERE id = @id";
    SqlConnection connection = new SqlConnection("your connection string");
    SqlCommand command = new SqlCommand(sql, connection);
    
    command.Parameters.AddWithValue("Systems", systeminfo);
    command.Parameters.AddWithValue("id", Id);
 
