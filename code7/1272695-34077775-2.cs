    string email = //where are you getting the email address
    string password = TextBox2.Text;
    string s = ConfigurationManager.ConnectionStrings["connection"].ToString();
    using (SqlConnection connStr new SqlConnection(s);
    using (SqlCommand cmd = new SqlCommand("Signup1", connStr))
    {
        c.Open();
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue"@password", password);
        command.Parameters.AddWithValue("@usrtype", userType); //Where are you assigning userType
        cmd.ExecuteNonQuery();
    }
