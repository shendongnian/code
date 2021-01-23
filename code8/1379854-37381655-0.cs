    public void UpdateBalance(string userId, decimal balanceChange)
    {
        //since we might need to execute two queries, we will create the paramaters once
        List<DbParamater> paramaters = new List<DbParamater>();
        DbParamater userParam = _factory.CreateParamater();
        userParam.ParamaterName = "@userId";
        userParam.DbType = System.Data.DbType.Int32;
        userParam.Value = userId;
        paramaters.Add(userParam);
        DbParamater balanceChangeParam = _factory.CreateParamater();
        balanceChangeParam.ParamaterName = "@balanceChange";
        balanceChangeParam.DbType = System.Data.DbType.Decimal;
        balanceChangeParam.Value = balanceChange;
        paramaters.Add(balanceChangeParam);
        //Improvement: if you implement a method to clone a DbParamater, you can
        //create the above list in class construction instead of function invocation 
        //then clone the objects for the function.
        using (DbConnection conn = _factory.CreateConnection()){
            conn.Open(); //Need to open the connection before you start the transaction
            DbTransaction trans = conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            //IsolationLevel.Serializable locks the entire table down until the
            //transaction is commited or rolled back.
            try {
                int changedRowCount = 0;
                //We can use the fact that ExecuteNonQuery will return the number
                //of affected rows, and if there are no affected rows, a 
                //record does not exist for the userId.
                using (DbCommand cmd = conn.CreateCommand()){
                    cmd.Transaction = trans; //Need to set the transaction on the command
                    cmd.CommandText = "UPDATE Users SET Balance = Balance + @balanceChange WHERE Id = @userId";
                    cmd.Paramaters.AddRange(paramaters.ToArray());
                    changedRowCount = cmd.ExecuteNonQuery();
                }
                if(changedRowCount == 0){
                    //If no record was affected in the previous query, insert a record
                    using (DbCommand cmd = conn.CreateCommand()){
                        cmd.Transaction = trans; //Need to set the transaction on the command
                        cmd.CommandText = "INSERT INTO Users (Id, Balance) VALUES (@userId, @balanceChange)";
                        cmd.Paramaters.AddRange(paramaters.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit(); //This will persist the data to the DB.
            }
            catch (Exception e){
                trans.Rollback(); //This will cause the data NOT to be saved to the DB.
                                  //This is the default action if Commit is not called.
                throw e;
            }
            finally {
                trans.Dispose(); //Need to call dispose
            }
            //Improvement: you can remove the try-catch-finally block by wrapping 
            //the conn.BeginTransaction() line in a using block. I used a try-catch here
            //so that you can more easily see what is happening with the transaction.
        }
    }
