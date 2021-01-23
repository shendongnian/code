    SqlCommand com = new SqlCommand(
                            "UPDATE Users " +
                            "SET Password = @password" + 
                            "WHERE Username = @username ;" , conn);
    com.Parameters.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar).Value = txtConfirmPassword.Text);
    com.Parameters.Add(new SqlParameter("@username", System.Data.SqlDbType.VarChar).Value = Session["Username"].ToString());
