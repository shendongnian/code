    result.Query="Update tbl_account set username=@0, password=@1, position=@2 where id=@3";
    result.Parameters = new Object[] { username, password, position, id };
    
        public int ExecuteNonQuery() {
        	DbProviderFactory dbFact = DbProviderFactories.GetFactory(conn.GetType().Namespace);
        	using (DbCommand cmd = dbFact.CreateCommand()) {
	        	cmd.Connection = conn;
    	    	cmd.CommandText = this.Query;
	        	for (int i = 0; i < Parameters.Length; i++) {
					var p = dbFact.CreateParameter();
					p.ParameterName = "@" + i;
					p.Value = Parameters[i];
        			cmd.Parameters.Add(p);
				}
	        	return cmd.ExecuteNonQuery();
			}
        }
