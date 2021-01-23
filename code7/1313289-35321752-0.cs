    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String"); //Here you can put the string that you'll use in your resx file
    SqlCommand cmd = new SqlCommand(); //Initialize the command object for executing instructions (queries)
    SqlDataReader reader;
    
    cmd.CommandText = "INSERT INTO TABLE_NAME_HERE VALUES (" + nameYouWillExtractFromTheUser + ")";
    cmd.CommandType = CommandType.Text; //We say that the command is a textType
    cmd.Connection = sqlConnection1; //Initiate the connection
    
    sqlConnection1.Open(); //Opens the connection
    
    reader = cmd.ExecuteReader(); //Execute the connection
        
