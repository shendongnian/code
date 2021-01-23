    using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        conn.Open();
        var session_username = Session["user"];
        string sql1 = "UPDATE Users SET email= @email WHERE username = @UserName";
        using(var cmd = new SqlCommand(sql1, conn))
        {
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = newemail.Text;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = session_username ;
            cmd.ExecuteNonQuery();
            Response.Write("alert('DATA UPDATED')");
        }
    }
