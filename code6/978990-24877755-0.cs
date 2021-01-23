    private void UpdateMemberRecords(Int32 memberId)
        {
        	
        string sql = string.Format("select * from Member where mem_id > {0}", memberId);
    	try {
    		DataTable dt = new DataTable();
    		using (SqlDataAdapter da = new SqlDataAdapter(new SqlCommand(sql, _sourceDb))) {
    			da.Fill(dt);
    		}
    
    		Console.WriteLine("Member Count: {0}", dt.Rows.Count);
    
    		using (SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.AppSettings("DestDb"), SqlBulkCopyOptions.KeepIdentity)) {
    			sqlBulk.BulkCopyTimeout = 600;
    			sqlBulk.DestinationTableName = "Member";
    			sqlBulk.WriteToServer(dt);
    		}
    	} catch (Exception ex) {
    		throw;
    	}
    }
