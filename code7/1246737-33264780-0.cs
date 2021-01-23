    int count = 0;
    using (SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["FleetManagementConnectionString"].ConnectionString))
    {
        SqlCommand command = new SqlCommand("Select Count(*) from dbo.UserLoggins where UserName =@User and Password =@Password", con);
        SqlParameter paramName = new SqlParameter("@User", SqlDbType.VarChar, 255) { Value = "HelloWorld1" };
        command.Parameters.Add(paramName);
        SqlParameter paramName = new SqlParameter("@Password", SqlDbType.VarChar, 255) { Value = "password" };
        command.Parameters.Add(paramName);
        con.Open();
        count = (int)cmd.ExecuteScalar();
        con.Close();
    }
    args.IsValid = count > 0;
    return;
