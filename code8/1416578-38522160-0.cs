     public string Balance()
        {
            string query = "SELECT balance FROM history ORDER BY id DESC LIMIT 1 ";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                return cmd.ExecuteScalar();
            }          
        }
