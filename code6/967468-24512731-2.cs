    int before_day = 0;
    DateTime sToday = DateTime.Now;
    string myConnection = "datasource= localhost;port=3306;username=root;password=root";
    using(MySqlConnection myConn = new MySqlConnection(myConnection))
    using(MySqlCommand SelectCommand = new MySqlCommand("SELECT* FROM bs.reminder ", myConn))
    {
        myConn.Open();
        using(MySqlDataReader myReader = SelectCommand.ExecuteReader())
        {
           while (myReader.Read())
           {
                // get the remainder_id. It is the primary key to use in the update where
                int reminderid = myReader.GetInt32(0); 
                date = myReader.GetDateTime(1);
                before_day = myReader.GetInt32(4);
    
                DateTime show_day = date.AddDays(-before_day);
                string constring = "datasource= localhost;port=3306;username=root;password=root";
                
                // Update query that limits to just the current record (reminder_id)
                string Query = @"update bs.reminder set status='s',show_day=@newDay 
                                 where reminderid=@id and status= 'p';";
                using(MySqlConnection conDataBase = new MySqlConnection(constring))
                using(MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
                {
                    cmdDataBase.Parameters.AddWithValue("@id", reminderid);
                    cmdDataBase.Parameters.AddWithValue("@newDay", show_day);
                    try
                    {
                        conDataBase.Open();
                        int rowAffected = cmdDataBase.ExecuteNonQuery();
                        ....
                    }
                }
            }
        }
    }
