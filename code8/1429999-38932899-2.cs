    // Both commands text are passed to the same SqlCommand
    string cmdText = @"SELECT Name from Customers where name = @name;
                       SELECT Mobile from Informations where Mobile = @mobile";
    SqlCommand sqlCmd = new SqlCommand(cmdText, con);
    // Set the parameters values....
    sqlCmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textview2.Text
    sqlCmd.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = textview3.Text
    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
    while (sqlReader.HasRows)
    {
         // Should be only one record, but to be safe, we need to consume
         // whatever there is in the first result
         while(sqlReader.Read())
             textview1.Text = (sqlReader["Name"].ToString());
         // Move to the second result (if any)
         if(sqlReader.NextResult())
         {
              // Again, we expect only one record with the mobile searched 
              // but we need to consume all the possible data 
             while(sqlReader.Read())
                textview4.Text = (sqlReader["Mobile"].ToString());
         }
    }
    sqlReader.Close();
