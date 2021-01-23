     private static void Select() {
    
           string cmdStr = "SELECT FirstName, LastName, Telephone FROM Person WHERE FirstName = @FirstName";
        
            using (SqlConnection connection = new SqlConnection(ConnectionString))
        
            using (SqlCommand command = new SqlCommand(cmdStr, connection)) {
        
                command.Parameters.AddWithValue("@FirstName", "John");
        
                connection.Open();
        
                SqlDataReader reader = command.ExecuteReader();
        
                while (reader.Read()) {
        
                    string output = "First Name: {0} \t Last Name: {1} \t Phone: {2}";
        
                    Console.WriteLine(output, reader["FirstName"], reader["LastName"], reader["Telephone"]);
        
                }
        
            }
        
        }
