    // Both commands text are passed to the same SqlCommand
    string cmdText = @"SELECT Name from Customers where name = @name;
                       SELECT Mobile from Informations where Mobile = @mobile";
    SqlCommand sqlCmd = new SqlCommand(cmdText, con);
    // Set the parameters values....
    sqlCmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textview2.Text
    sqlCmd.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = textview3.Text
    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
    while (sqlReader.Read())
    {
         textview1.Text = (sqlReader["Name"].ToString());
         if(sqlReader.NextResult())
            textview4.Text = (sqlReader["Mobile"].ToString());
    }
    sqlReader.Close();
