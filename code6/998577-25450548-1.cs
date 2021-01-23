    //why on earth would you ever return an Age as a string!?
    public int getAge(string Name) 
    {
        //Notice the placeholder in the string. This is important.
        string sql = "Select Age from profile where Name = @Name ;";
        //I see you have your own connection class. However, you used it wrong.
        //If you can't wrap your connection in a using block or try/finally block
        // you're potentially leaving connections hanging open.
        // Do that enough, and you'll lock yourself out of your database.
        //Better just to provide the connection string as a property
        using (var cn = new MySqlConnection("connection string here"))
        using (var cmd = new MySqlCommand(sql, cn))
        { 
            //use the actual db type and length here
            // this parameter makes your code safe from sql injection attacks
            // without the parameter, you're practically begging to get hacked.
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name;  
            cn.Open();          
            using (var reader = cmd.ExecuteReader())
            {
                //no need to ever check HasRows. 
                //If HasRows would return false, so will reader.Read(), and everything still works the same
                if (reader.Read())
                {
                    //surely you're not storing this information in the database as a string!?
                    // that would be awful.
                    // Age should be an integer.
                    // More than that, you should be storing a date, and then calculate the age on retrieval
                    DateTime origin = Reader.GetDateTime(0);
                    int Age = DateTime.Today.Year - origin.Year;
                    if (origin > today.AddYears(-Age)) Age--;
                    return Age;
                }
            }
        }
        return 0; //or throw an exception here
    }
