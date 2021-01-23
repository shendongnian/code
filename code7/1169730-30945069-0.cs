    private static int runupdates(string arr)
    {
        updatestatement = "";
        using (SqlConnection connection = new SqlConnection(SQLConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(updatestatement, connection))
            {
            command.CommandText = updatestatement;
            int nummmm = command.ExecuteNonQuery();
            connection.Close();
            }
        }
        return nummmm;
    }
