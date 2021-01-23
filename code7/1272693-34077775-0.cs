    string email = //where are you getting the email address
    string password = TextBox2.Text;
    string s = ConfigurationManager.ConnectionStrings["connection"].ToString();
    using (SqlConnection connStr new SqlConnection(s);
    using (SqlCommand cmd = new SqlCommand("Signup1", connStr))
    {
        c.Open();
        command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar) { Value = email });
        command.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar) { Value = password });
        command.Parameters.Add(new SqlParameter("@usrtype", SqlDbType.VarChar) { Value = userType }); //Where are you assigning userType
        object obj = (object)command.ExecuteNonQuery();
    }
