    result.Query="Update tbl_account set username=@0, password=@1, position=@2 where id=@3";
    result.Parameters = new Object[] { username, password, position, id };
    
        public int ExecuteNonQuery() {
        	IDbCommand cmd = ...;
        	cmd.Connection = ...;
        	cmd.CommandText = this.Query;
        	for (int i = 0; i < Parameters.Length; i++)
        		cmd.Parameters.Add("@" + i, Parameters[i]);
        	cmd.ExecuteNonQuery();
        }
