    string locationCode = Server.UrlDecode(Request["locationCode"].ToString().Trim());
    string ID = Server.UrlDecode(Request["id"].ToString().Trim());
    
    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["MyAccounts"]))
    {
    	con.Open();
    	using (var cmd = new SqlCommand(
    	@"SELECT COUNT(EstablishmentCode) 
    	  FROM Establishments 
    	  WHERE EstablishmentCode = @locationCode  AND ID <> @ID",
    	con))
    	{
    		cmd.Parameters.AddWithValue("@locationCode", locationCode);
    		cmd.Parameters.AddWithValue("@ID", ID);
    		Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
    
    	}
    }
