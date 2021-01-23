    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Your Connection string goes here";
            var commandStatement = "INSERT INTO Metamorphic (rock_Name, rock_Color, rock_Feature, rock_Mineral)"
            + "VALUES (@rock_Name, @rock_Color, @rock_Features, @rock_Mineral)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandStatement, connection))
            {
                command.Parameters.AddWithValue("@rock_Name", "One");
                command.Parameters.AddWithValue("@rock_Color", "Two");
                command.Parameters.AddWithValue("@rock_Features", "Thre");
                command.Parameters.AddWithValue("@rock_Mineral", "Four");
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            } 
        }
    }
           
