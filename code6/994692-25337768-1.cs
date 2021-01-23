    SqlConnection con = new SqlConnection(connectionString);
    SqlCommand com = new SqlCommand("ADD_TO_BEFORE_PATH_SP", con);
    com.Parameters.AddWithValue("@fname", fname_tb.Text);
    com.Parameters.AddWithValue("@lname", lname_tb.Text);
    com.CommandType = CommandType.StoredProcedure;
    try
    {
        con.Open();
        com.ExecuteNonQuery();
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        if (con.State == ConnectionState.Open)
            con.Close();
    }
