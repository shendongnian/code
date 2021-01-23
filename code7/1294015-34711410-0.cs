    .....
    string cmdText = @"select account_no,registration_date, other_field1, 
                       other_field2, other_fieldN
                       from users 
                       where email_1 = @email";
    using(SqlConnection oSqlConnection = new SqlConnection(cpUsersConnection))
    using(SqlCommand oSqlCommand = new SqlCommand(cmdText, oSqlConnection))
    {
         oSqlConnection.Open();
         oSqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = str;
         using(SqlDataReader reader = oSqlCommand.ExecuteReader())
         {
            if (reader.Read())
            {
                 AcNo.Text = reader["account_no"].ToString();
                 RegDate1.Text = reader["registration_date"].ToString();
                 otherTextBox.Text = reader["other_field1"].ToString();
                 ... and so on ...
            }
        }
    }
