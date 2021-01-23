    protected void cvUsername_ServerValidate(object source, ServerValidateEventArgs args)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Job_Registration_ConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT ID FROM Job_UserData WHERE Username=@Username";
        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
        SqlDataReader data = cmd.ExecuteReader();
        if (data.HasRows) // Username is existing
            args.IsValid = true; // will display error message
        else
            args.IsValid = false;
        con.Close();
        con.Dispose();
    }
