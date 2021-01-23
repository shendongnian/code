           SqlDataReader sdrData  = null;
			// create a connection object
			SqlConnection conn = new SqlConnection(create your sql connection string here );
	// create a command object
      SqlCommand cmd  = new SqlCommand("LoadStates", conn);
        sqlCmd.CommandType = CommandType.StoredProcedure;
			try
			{
				// open the connection
				conn.Open();				
				sdrData = cmd.ExecuteReader();
                while (sdrData.Read())
                        {
                            //string strDBNme = sdrData.ToString();
                            string strDBNme = (string)sdrData["States"];
                            cmbxACState.Items.Add(strDBNme);
                        }
				
			}
			finally
			{
				// 3. close the reader
				if (sdrData != null)
				{
					sdrData.Close();
				}
				// close the connection
				if (conn != null)
				{
					conn.Close();
				}
			}	
		
