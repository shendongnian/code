        public bool user_check(string username, string password)
        {
            string query = "SELECT username, password from swear_tool where username='" + username + "' and password = '" + password + "'";
            if (this.OpenConnection())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            return false;
        }
