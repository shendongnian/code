    using (SqlConnection con = new SqlConnection(dc.Con)) {
    	using (SqlCommand cmd = new SqlCommand("sp_EditItem", con)) {
    		using  (SqlTransaction transaction = connection.BeginTransaction("SampleTransaction"))
    		{
    			try
    			{
    				cmd.Transaction = transaction;
    				cmd.CommandType = CommandType.StoredProcedure;
    
    				cmd.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = txtItemInfo.Text;
    				cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtItemID.Text;
    
    				con.Open();
    				cmd.ExecuteNonQuery();
    				transaction.Commit();
    			}
    			catch (Exception ex)
    			{
    				transaction.Rollback();
    			}
    		}
    	}
    }
