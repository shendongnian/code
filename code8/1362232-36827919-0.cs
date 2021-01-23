    public bool ValidData(string username, string email, string connectionString)
    {
        var c = new SqlConnection(connectionString);
        var cmdUsername = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName = @userName AND email = @email;", c);
        cmdUsername.Parameters.AddWithValue("userName", username);
        cmdUsername.CommandType = System.Data.CommandType.Text;
        cmdUsername.Parameters.AddWithValue("email", email);
        c.Open();
        try
        {
            return (int) cmdUsername.ExecuteScalar() > 0;
        }
        catch (Exception ex)
        {
            //log exception
            return false;
        }
        finally
        {
            c.Close();
        }
    }
