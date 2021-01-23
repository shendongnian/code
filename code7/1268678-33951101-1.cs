    mSqlCommand = new SqlCommand("OpMngSys.USP_CostumerLogin", mSqlConnection);
    mSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
    mSqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = pUser.UserName;
    mSqlCommand.Parameters.Add("@Password", SqlDbType.VarChar, 150).Value = pUser.Password;
    mSqlConnection.Open();
    object resultset = mSqlCommand.ExecuteScalar();
    mSqlConnection.Close();
   
    bool userDoesExist;
    if(resultset != null)
    {
        if (bool.TryParse(resultset.ToString(), out userDoesExist))
        {
           return userDoesExist;
        }
        else
        {
            // ERROR: cannot convert result to a "bool"
        }
    }
