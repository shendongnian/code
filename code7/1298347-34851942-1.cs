    private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
    {
        SqlConnection mySC = new SqlConnection();
        SqlDataReader reader;
        mySC.ConnectionString = ("Data Source=localhost;Initial Catalog=RCA;Integrated Security=True");
        mySC.Open();
        string sql = @"SELECT * FROM RCA Where EmailID = @emailid;";
        using(var command = new SqlCommand(sql, mySC))
        {
            command.Parameters.Add("@emailid", txtEmail.Text);
            reader = command.ExecuteReader();
        }
        if(reader.HasRows)
        {
    		//Email Exsist in the dataBase.
        }
    	else
    	{
    		MessageBox("Incorrect!!");
    	}
        mySC.Close();
    }
