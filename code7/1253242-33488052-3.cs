    public bool loginCorrect(String name, String HASHED_AND_SALTED_PASSWORD)
        {
            bool isExist;
            if (this.OpenConnection()) {
                using (SqlCommand cmd = new SqlCommand ("SELECT * FROM logins WHERE `name` = @UserName AND password = @Password")) {
                    cmd.Parameters.AddWithValue ("@UserName", name);
                    cmd.Parameters.AddWithValue ("@Password", HASHED_AND_SALTED_PASSWORD);
                    //Now we are going to read the data imput
                    SqlDataReader myLoginReader = cmd.ExecuteReader ();
                    //if the data matches the rows (username, password), then you enter to the page                 
                    isExist = myLoginReader.HasRows;
    
                    //Close Reader                 
                    myLoginReader.Close ();            
                }                          
                //Close Connection             
                this.CloseConnection ();
            }
    
            return isExist;
        }
