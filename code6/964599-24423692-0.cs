    // Note: I changed the name to a more meaningfull use
    public static bool UserExists(string alias)
    {
        bool userExists = false;
        try
        {
            // Note: where do you initialise cmd?
            cmd.Parameters.AddWithValue("alias", alias);
            cmd.CommandText = "Select count(*) from cntc_employee where emp_alias=@alias";
            cmd.Connection = con;
            OpenCnn();
            int amountOfUsersWithAlias = (int)cmd.ExecuteScalar();
            if(amountOfUsersWithAlias > 0)
                  userExists = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseCnn();
        }
        return userExists;
    }
