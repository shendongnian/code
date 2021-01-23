    using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Categories where Category = @1", con))
    {
        con.Open();
        sqlCommand.Parameters.AddWithValue("@1", txtName.Text);
        int userCount = (int) sqlCommand.ExecuteScalar();
        if(userCount == 1)
    {
    //already exists
    }
    else
    {
    //proceed
    }
    }
