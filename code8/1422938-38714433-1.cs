    public bool user_check(string username, string password)
    {
        string query = "SELECT username, password from swear_tool where username='" + username + "' and password = '" + password + "'";
        bool hasRecords = false;
        if (this.OpenConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    hasRecords = true;
                    break;
                }
            }
            dataReader.Close();
            this.CloseConnection();
        }
        return hasRecords;
    }
