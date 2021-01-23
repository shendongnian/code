    public bool IsAdmin(string u_name, string u_password)
    {
    string role="";
    string sql = "select u_role from user_sys
    where u_name=@u_name and u_password= @u_password";
    using (SqlConnection conn = new SqlConnection(connection.connectstr))
    {
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@u_name", u_name));
        cmd.Parameters.Add(new SqlParameter("@u_password", u_password));
        try
        {
            conn.Open();
            role = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //handle error
        }
    }
    return role == "admin";
    }
