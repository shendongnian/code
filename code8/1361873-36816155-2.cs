        string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True";
        string userName = txtUserNameLogIN.Text;
        string password = txtPasswordLogIN.Text;
        SqlConnection c = null;
        try
        {
            using (c = new SqlConnection(str))
            {
                using (var cmd = new SqlCommand("SELECT COUNT(1) FROM [Table] WHERE UserName = @userName", c))
                {  
                    cmd.Parameters.AddWithValue("@userName", userName);
                    var existingCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (existingCount > 0)
                    {
                        // exists logic
                    }
                }
            }
        }
        catch(Exception exc)
        {
            // exception handling code comes here
        }   
        finally
        {
            // ensure that connection is properly closed, if database operation is done
            if (c != null && c.State == ConnectionState.Open)
                c.Close();
        }
