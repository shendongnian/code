    /// <summary>
    /// Test that the server is connected
    /// </summary>
    /// <param name="connectionString">The connection string</param>
    /// <returns>true if the connection is opened</returns>
    private static bool IsServerConnected(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
