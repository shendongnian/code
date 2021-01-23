     using (SqlConnection sourceConnection =
                   new SqlConnection(connectionString))
        {
            sourceConnection.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(
                "SELECT * FROM " +
                "dbo.Users group by user_Name;",
                sourceConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
               //Get the record which you can use to filter the main Dataset 
               //apply the above code snippet shared to filter main Dataset.
               //Create Excel
               //Send Mail
            } 
        }
