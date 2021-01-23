    public List<User> Select() {
        
        List<User> list = new List<User>();
        
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                User user = new User();
                
                user.Id = dataReader["id"];
                user.Test = dataReader["test"];
                user.Balance = dataReader["balance"];
                
                list.Add(user);
            }
            dataReader.Close();
            this.CloseConnection();
        }
        
        return list;
    }
