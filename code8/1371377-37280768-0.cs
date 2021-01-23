    public int SimpleDBUpdateTable(string strQuery)
        {
            int nRows;
            try
            {
                DbProviderFactory factoryProvider = DbProviderFactories.GetFactory(_strDbProvider);
                using (DbConnection connDb = factoryProvider.CreateConnection())
                {
                    try
                    {
                        connDb.ConnectionString = _strDbConnection;
                        connDb.Open();
                        using (DbCommand cmdDb = connDb.CreateCommand())
                        {
                            cmdDb.CommandText = strQuery;
                            nRows = cmdDb.ExecuteNonQuery();
                            return nRows;
                        }
                    }
                    catch (DbException ex)
                    {
                        throw;
                    }
                    finally
                    {
                        if (connDb.State != ConnectionState.Closed)
                        {
                            connDb.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
