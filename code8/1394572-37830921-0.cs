    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
    using (SqlCommand command = new SqlCommand(
		"SELECT COUNT(*) from [UserData] where UserName= @Name", connection))
	{
		// Add new SqlParameter to the command.
		command.Parameters.Add(new SqlParameter("Name", TextBox1UN.Text));
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if(temp==1)
        {
            Response.Write("user allready exists");
        }
	}
