    public User AuthenticateUser(string username, string clearTextPassword){
    		var List<InternalUserData> _users = GetUsersList();
                InternalUserData userData = _users.FirstOrDefault(u => u.Username.Equals(username) 
                    && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
                if (userData == null)
                    throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
     
                return new User(userData.Username, userData.Email, userData.Roles);
            }
    
    Public List<InternalUserData> GetUsersList(){
       string sql = "SELECT Username, Email, Password, Userole FROM USER"; 
        command.CommandText = sql; 
     var List< InternalUserData> listUsers = new List< InternalUserData>();
        OracleDataReader reader = command.ExecuteReader(); 
        while (reader.Read()) 
        {
    listUsers.Add( new InternalUserData((string)reader["Username"], (string)reader["Email"], (string)reader["Password"],new string[] { (string)reader["Userole "]})
        }
    return listUsers;
    	
    }
      
