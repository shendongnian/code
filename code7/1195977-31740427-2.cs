    var connectionString = "YOUR CONNECTION STRING";
    var queryString = "SQL QUERY";
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(queryString, connection))
    using (SqlDataReader dateReader = command.ExecuteReader()) {
    }
