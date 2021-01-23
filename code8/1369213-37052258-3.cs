    public bool UserAvailable(string chkUserEmailPhone)
    {
       using(SqlConnection cnn = new SqlConnection(....))
       using(SqlCommand cmd = new SqlCommand("proc_CheckingUserEmailMobile", cnn))
       {
           cnn.Open();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@chkUserEmailPhone", SqlDbType.NVarChar).Value = chkUserEmailPhone;
           int result = Convert.ToInt32(cmd.ExecuteScalar())
           return !(result == 1)
       }
    }
