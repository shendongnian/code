    string connectionString = "Data Source=DEFIANT\\SQL2012; Initial Catalog=HRD_MIS_Jobs2009; User ID=id; Password=password";
    string storedProcedureName = "dbo.spr_Reports_JobsBreakdown4";
    // establish connection to DB, define command to execute stored procedure
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
    {
        try
        {
            // set type of command to stored procedure
    		cmd.CommandType = CommandType.StoredProcedure;
    
            // define parameters
            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@datefrom", SqlDbType.DateTime);
            cmd.Parameters.Add("@dateto", SqlDbType.DateTime);
    
   		    conn.Open();
   		    Console.WriteLine("successful connection");
    
            // set parameter values
            cmd.Parameters["@user"].Value = ......;
            cmd.Parameters["@datefrom"].Value = ......;
            cmd.Parameters["@dateto"].Value = ......;
    
            // execute stored procedure, handle return values
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
			     while (reader.Read())
                 {
    			     // handle your data here.....
                 }
    
                 reader.Close();
            }
    
            conn.Close();
    	}
    	catch (Exception ex)
    	{
    	    Console.WriteLine(ex);
    	}
    }
