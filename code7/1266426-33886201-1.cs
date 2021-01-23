      public static bool GetNextOpponent(int userID)
        {   
            MySqlConnection conn = null;
            boolean resp ;
            //we assume that if fails
            resp = false ;
            try
            {
                conn = new MySqlConnection(ConnectionString);
		if(conn != null)
		{
		        conn.Open();
		        using (var cmd = new MySqlCommand("GetNextOpponent", conn) {CommandType = CommandType.StoredProcedure})
		        {
			    //Addding parameters to the SQL commands - good comments never hurt
		            cmd.Parameters.Add("@p_user_id", MySqlDbType.Int32).Value = userID;
		            cmd.Parameters.Add("@p_target_id", MySqlDbType.Int32).Direction = ParameterDirection.Output;
		            cmd.Parameters.Add("@p_target_data", MySqlDbType.MediumBlob).Direction = ParameterDirection.Output;
		            cmd.Parameters.Add("@p_target_rank", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                            //you are executing a NonQuery but expectin results ??
		            cmd.ExecuteNonQuery();
			    //see comments above
		            object a = cmd.Parameters["@p_target_id"].Value;    // null 
		            object b = cmd.Parameters["@p_target_data"].Value;  // null
		            object c = cmd.Parameters["@p_target_rank"].Value;  // null =(
                            //avoid returns in the middle of the flow until debug works
		            //return true;
                            resp = true ;
		        }
		}
            }
            catch (Exception ex)
            {
                Logger.LogError($"Unexpected exception of type {ex.GetType()}: {ex.Message}");
            }
            finally
            {
		if(conn != null)
                {
                    conn?.Close();
                }
            }
        }
