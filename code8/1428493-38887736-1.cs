    MySqlCommand cmd = dbConn.CreateCommand();
    cmd.CommandText = "SELECT id from companies WHERE name ='" + companyName + "'";
    
    try
    {
        dbConn.Open();                
    } catch (Exception e) {
        //Connection failed. Handle it here
    }
    
    MySqlDataReader reader = cmd.ExecuteReader();
    
    while (reader.Read())
    {
        //Assuming it'll return atleast one row with ID
        Company_Number_ID = Convert.ToInt32(reader["id"].ToString());
        //If you want keep iterating over the rows, remove this
        //Note that the variable `Company_Number_ID` will be constantly overwritten with new value. Therefore decide how you are going to handle multiple rows, if you are going to do that.
        break;
    }
    //Close the reader
    reader.Close();
