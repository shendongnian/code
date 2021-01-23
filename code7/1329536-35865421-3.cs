    protected void submitButton_Click(object sender, EventArgs e)
    {
        SqlConnection myConnection = null;
        try
        {
            using (myConnection = GetConnection())
            {
                myConnection.Open();
                String myQuery = @"
                    INSERT INTO RegistrationDB([firstName], [lastName], [eMail], [dob], [userName], [password]) 
                    values (@firstName, @lastName, @eMail, @dob, @userName, @password)";
    
                using (SqlCommand myCommand = new SqlCommand(myQuery, GetConnection())
                { 
                    myCommand.Parameters.AddWithValue("@firstName", fNameBox.Text);
                    myCommand.Parameters.AddWithValue("@lastName", lNameBox.Text);
                    myCommand.Parameters.AddWithValue("@eMail", emailBox.Text);
                    myCommand.Parameters.AddWithValue("@dob", dobBox.Text);
                    myCommand.Parameters.AddWithValue("@userName", userNameBox.Text);
                    myCommand.Parameters.AddWithValue("@password", passwordBox.Text);
                    myCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            if (myConnection != null)
                myConnection.Close();
        }
    }
