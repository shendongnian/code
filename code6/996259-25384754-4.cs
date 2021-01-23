    public System.Data.Common.DbProviderFactory GetFactory()
            {
                System.Data.Common.DbProviderFactory providerFactory = null;
                providerFactory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
                return providerFactory;
            } // End Function GetFactory
    protected System.Data.Common.DbProviderFactory m_providerFactory = null;
    m_providerFactory = GetFactory();
		public System.Data.IDbConnection GetConnection(string strDb)
		{
			System.Data.Common.DbConnection con = m_providerFactory.CreateConnection ();
			con.ConnectionString = GetConnectionString (strDb);
			return con;
		}
            public  System.Data.DataTable GetDataTable(System.Data.IDbCommand cmd, string strDb)
    		{
    			System.Data.DataTable dt = new System.Data.DataTable();
    			
    			using (System.Data.IDbConnection idbc = GetConnection(strDb))
    			{
    				
    				lock (idbc)
    				{
    					
    					lock (cmd)
    					{
    						
    						try
    						{
    							cmd.Connection = idbc;
    							
    							using (System.Data.Common.DbDataAdapter daQueryTable = this.m_providerFactory.CreateDataAdapter())
    							{
    								daQueryTable.SelectCommand = (System.Data.Common.DbCommand)cmd;
    								daQueryTable.Fill(dt);
    							} // End Using daQueryTable
    							
    							
    							/*
                                using (System.Data.SqlClient.SqlDataAdapter daQueryTable = new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)cmd))
                                {
                                    daQueryTable.Fill(dt);
                                } // End Using daQueryTable
                                */
    						} // End Try
    						catch (System.Data.Common.DbException ex)
    						{
    							//COR.Debug.MsgBox("Exception executing ExecuteInTransaction: " + ex.Message);
    							Log("cMS_SQL.GetDataTable(System.Data.IDbCommand cmd)", ex, cmd.CommandText);
                                throw;
    						}// End Catch
    						finally
    						{
    							if (idbc.State != System.Data.ConnectionState.Closed)
    								idbc.Close();
    						} // End Finally
    						
    					} // End lock cmd
    					
    				} // End lock idbc
    				
    			} // End Using idbc
    			
    			return dt;
    		} // End Function GetDataTable
