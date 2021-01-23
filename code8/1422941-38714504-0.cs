    public bool user_check(string username, string password)
    {
        string query = "SELECT username, password from swear_tool where username='" + username + "' and password = '" + password + "'";
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            dataReader.Close();
            this.CloseConnection();
        }
    }
