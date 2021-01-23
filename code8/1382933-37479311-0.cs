    string constring = databaselocation
    SqlConnection conData = new SqlConnection(constring);
    SqlCommand cmdData = new SqlCommand(query, conData);
    SqlDataReader myReader;  
    try
    {
        conData.Open();
        // I am assuming here you are trying to access user/password
        myReader = cmdData.ExecuteReader();
        
        // and then you want to verify if you receive any row for that combination
        if(myReader.HasRows)
        {
            // then your record deletion code should go here
            // ...
            // ...
    
            MessageBox.Show("member has been deleted");
        }
        else
        {
             throw new Exception("Username and password is wrong! Cannot delete record");
        } 
    
    }
    catch (Exception e)
    {
        MessageBox.Show(e.Message);
    }
