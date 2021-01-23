        try
        {
            SqlCommand cmd = new SqlCommand("AddUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = txtUserId.Text;
            cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value = txtPassword.Text;
            cmd.Parameters.Add("@ConfirmPassword", SqlDbType.NVarChar).Value = txtConfirmPassword.Text;
            cmd.Parameters.Add("@Mobile", SqlDbType.Int).Value = txtMobile.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@BirthDate", SqlDbType.NVarChar).Value = txtBirth.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("http://www.google.com");
            con.Close();
        }
        catch (Exception ex)
        {
            // 
        }
