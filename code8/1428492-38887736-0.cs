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
    }
