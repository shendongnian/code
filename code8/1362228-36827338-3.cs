    string myConnection=str;//this is your connection string
    string userName="";
    string email="";
    string parameteruserName = "";//your parameter should goes here
    string parameterEmail = "";//your parameter should goes here
    try
    {
        SqlDataReader myReader = null;
        SqlCommand    myCommand = new SqlCommand("IF ( "SELECT UserName ,Email 
    FROM  Users WHERE UserName =" +parameteruserName+" or  Email ="+parameterEmail 
       ) > 0 
        SELECT  1
    ELSE 
    SELECT  0 "+  ";", 
                                                 myConnection);
        myReader = myCommand.ExecuteReader();
        while(myReader.Read())
        {
          userName=  myReader["UserName"].ToString();
          email=  myReader["Email "].ToString();
        }
    myReader.close();
    myConnection.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    
    if(email=""){
    //your email is empty
    }
    if(userName=""){
    //your user name is empty
    }
