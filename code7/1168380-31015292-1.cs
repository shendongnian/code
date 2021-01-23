    public List<Models.eConnectModels.eConnStatus> CommitAsTransaction(List<SqlCommand> commands) {
                SqlTransaction transaction = null;
                SqlConnection connection = null;
                List<eConnStatus> ErrorList = new List<eConnStatus>();
                try {
                    connection = this.CreateSqlConnection();
                    connection.Open();
                    transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted, "TransactionID");
    
                    foreach (SqlCommand cmd in commands) {
                       eConnStatus curErr = new eConnStatus();
                        cmd.Transaction = transaction;
                        cmd.Connection = connection;
                        SqlParameter errorString = cmd.Parameters.Add("@oErrString", SqlDbType.VarChar);
                        errorString.Direction = ParameterDirection.Output;
                        errorString.Size = 8000;
    
                        SqlParameter errorStatus = cmd.Parameters.Add("@O_iErrorState", SqlDbType.Int);
                        errorStatus.Direction = ParameterDirection.Output;
    
                        cmd.ExecuteNonQuery();
                        curErr.ErrorState = (int)cmd.Parameters["@O_iErrorState"].Value;
                        curErr.ErrorMessage = (string)cmd.Parameters["@oErrString"].Value;
                        ErrorList.Add(curErr);
                    }
    
                    transaction.Commit();
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    connection.Close();
                    throw ex;
                }
                connection.Close();
                return ErrorList;
            }
