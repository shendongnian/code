    string myConnection=str;//this is your connection string
    string userName="";
    string email="";
    try
    {
        SqlDataReader myReader = null;
        SqlCommand    myCommand = new SqlCommand("SELECT UserName ,Email FROM Users WHERE UserName = @userName or  Email = @email ;", 
                                                 myConnection);
        myReader = myCommand.ExecuteReader();
        while(myReader.Read())
        {
          userName=  myReader["UserName"].ToString();
          email=  myReader["Email "].ToString();
        }
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
