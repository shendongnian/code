    public int Entrar(User pUser) {
        int logresult = 0;
        try {
            if (CreateConnection())
            {
                if (mSqlConnection != null && mSqlConnection.State != ConnectionState.Open) {
                    mSqlConnection.Open();
                }
    
                mSqlCommand = new SqlCommand("OpMngSys.USP_CostumerLogin");
                mSqlCommand.Connection = mSqlConnection;
                mSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
    
                mSqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = pUser.UserName;
                mSqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = pUser.Password;
    
                SqlParameter outputIsExists = new SqlParameter("@IsExists", SqlDbType.Int) {
                    Direction = ParameterDirection.Output
                };
    
                mSqlCommand.Parameters.Add(outputIsExists);
    
                mSqlCommand.ExecuteNonQuery();
    
                logresult = (int)outputIsExists.Value;
            }
    
            return logresult;
    
        }catch (Exception ex)
        {
            throw ex;
        }
    }
