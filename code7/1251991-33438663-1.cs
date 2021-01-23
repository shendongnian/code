    SqlCommand com = new SqlCommand(
                            "UPDATE Users " +
                            "SET Password = @Password" + 
                            "WHERE Username = " + Session["Username"] + " ", conn);
    com.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.VarChar).Value = txtConfirmPassword.Text);
