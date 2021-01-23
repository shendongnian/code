    public bool user_check(string username, string password){
        string query = "SELECT username, password From swear_tool Where "+
                       "username=@uname and password=@password";
        if (this.OpenConnection() == true){
            using(MySqlCommand cmd = new MySqlCommand(query, connection)){
                cmd.Parameters.AddWithValue("@uname",usename);
                cmd.Parameters.AddWithValue("@password",password);
                using(MySqlDataReader dataReader = cmd.ExecuteReader()){
                    if (dataReader.HasRows){
                        while(dataReader.Read()){
                            return true;
                        }
                    }
                }
            }
            this.CloseConnection();                    
        }
        return false;
    }
