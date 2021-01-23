    private static System.Data.Common.DbProviderFactory m_factory = System.Data.Common.DbProviderFactories.GetFactory(typeof(System.Data.SqlClient.SqlClientFactory).Namespace);
    
    public static string getConnectionString()
    {
        System.Data.SqlClient.SqlConnectionStringBuilder csb = new System.Data.SqlClient.SqlConnectionStringBuilder();
        csb.DataSource = System.Environment.MachineName;
        csb.InitialCatalog = "TestDb";
        csb.IntegratedSecurity = true;
        return csb.ConnectionString;
    }
    
    
    public static System.Data.Common.DbConnection GetConnection()
    {
        var con = m_factory.CreateConnection();
        con.ConnectionString = getConnectionString();
        return con;
    }
    public static int BatchedInsert(System.Collections.IList ls)
    {
        int iAffected = 0;
        int batchSize = 100; // Each batch corresponds to a single round-trip to the DB.
        using (System.Data.IDbConnection idbConn = GetConnection())
        {
            lock (idbConn)
            {
                using (System.Data.IDbCommand cmd = idbConn.CreateCommand())
                {
                    lock (cmd)
                    {
                        if (cmd.Connection.State != System.Data.ConnectionState.Open)
                            cmd.Connection.Open();
                        using (System.Data.IDbTransaction idbtTrans = idbConn.BeginTransaction())
                        {
                            try
                            {
                                cmd.Transaction = idbtTrans;
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                for (int i = 0; i < ls.Count; ++i)
                                {
                                    sb.Append("INSERT INTO T_TransactionInsertTest(TestValue) VALUES ( ");
                                    sb.Append(ls[i].ToString());
                                    sb.AppendLine(");");
                                    if (i % batchSize == 0 && i != 0)
                                    {
                                        cmd.CommandText = sb.ToString();
                                        iAffected += cmd.ExecuteNonQuery();
                                        sb.Length = 0;
                                    }
                                }
                                if (sb.Length != 0)
                                {
                                    cmd.CommandText = sb.ToString();
                                    iAffected += cmd.ExecuteNonQuery();
                                }
                                
                                idbtTrans.Commit();
                            } // End Try
                            catch (System.Data.Common.DbException ex)
                            {
                                if (idbtTrans != null)
                                    idbtTrans.Rollback();
                                iAffected = -1;
                                //if (Log(ex))
                                throw;
                            } // End catch
                            finally
                            {
                                if (cmd.Connection.State != System.Data.ConnectionState.Closed)
                                    cmd.Connection.Close();
                            } // End Finally
                        } // End Using idbtTrans
                    } // End lock cmd
                } // End Using cmd 
            } // End lock idbConn
        } // End Using idbConn
        return iAffected;
    } // End Function BatchedInsert 
