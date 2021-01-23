    public bool login(string user, string password, ref string isAdmin){        
     
        //This is used so we know if we entered the while loop...
        bool success = false;
        //This is what I am going to use to execute commands
        myCommand = new SqlCommand("SELECT isAdmin FROM users WHERE user = @user AND pass = @pass", myConnection);
        myCommand.Parameters.Addwithvalue("@user", user);
        myCommand.Parameters.Addwithvalue("@pass", password); 
        try
        {
            //Open connection
            myConnection.Open();
            //Execute the reader
            myReader = myCommand.ExecuteReader();
            //Read the data now
            while(myReader.Read())
            {
                //isAdmin could very well be an int and myReader could convert to int instead of string
                isAdmin = myReader[0].ToString();   
            
                success = true;
            }
            //Close connection
            myConnection.Close();
        }
        catch
        {
            //Error checking
            myConnection.Close();
            return false;
        }
        if(success)
        {
            //Login worked - credentials were right
            return true;
        }
        //Login failed - credentials were wrong
        return false;
    }
