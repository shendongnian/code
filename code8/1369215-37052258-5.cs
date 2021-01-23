    public bool IsUserAvailable(string chkUserEmailPhone)
    {
       using(SqlConnection cnn = new SqlConnection(....))
       using(SqlCommand cmd = new SqlCommand("proc_CheckingUserEmailMobile", cnn))
       {
           cnn.Open();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@chkUserEmailPhone", SqlDbType.NVarChar).Value = chkUserEmailPhone;
           int result = Convert.ToInt32(cmd.ExecuteScalar())
           // SP return 1 if the data exists, so we need to negate 
           // to get true if the user data is available for a new record.
           return !(result == 1)
       }
    }
