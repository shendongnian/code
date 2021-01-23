    string myConnection=str;//this is your connection string
    string userName="";
    string email="";
    string parameteruserName = "";//your parameter should goes here
    string parameterEmail = "";//your parameter should goes here
    try
    {
        SqlDataReader myReader = null;
        SqlCommand    myCommand = new SqlCommand(SELECT COUNT(*) as count FROM  Users WHERE UserName =" +parameteruserName+" or  Email ="+parameterEmail 
       )  "+  ";", 
                                                 myConnection);
        myReader = myCommand.ExecuteReader();
        while(myReader.Read())
        {
          userName=  myReader["count"].ToString();
          
        }
    myReader.close();
    myConnection.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    
   
    if(userName=""){
    //your user name is empty
    }
