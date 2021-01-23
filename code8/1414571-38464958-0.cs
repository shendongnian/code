    DataSet ds= new DataSet();
    using (OleDbConnection conn= new OleDbConnection(connStr))
    {
   	 OleDbCommand command = new OleDbCommand(sql, conn);
    	conn.Open();
	   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
	   {
 		   da.Fill(ds);
	   }
       
    }
