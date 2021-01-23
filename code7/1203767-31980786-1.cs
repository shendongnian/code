    private bool CheckStatus()
    {
    bool wasSuccessful = false;
    using (SqlConnection con = new SqlConnection(CS))
    {
        cmd = new SqlCommand("spEcovaGetFilesJobStats", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        wasSuccessful = (bool)cmd.ExecuteScalar();
        con.Close();
        return status;
    }
