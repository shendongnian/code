    public static bool GetNextOpponent(int userID)
            {   
                MySqlConnection conn = null;
    
                try
                {
                    conn = new MySqlConnection(ConnectionString);
                    conn.Open();
    
                    using (var cmd = new MySqlCommand("GetNextOpponent", conn) {CommandType = CommandType.StoredProcedure})
                    {
                        cmd.Parameters.Add("@p_user_id", MySqlDbType.Int32).Value = userID;
                        cmd.Parameters.Add("@p_target_id", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@p_target_data", MySqlDbType.MediumBlob).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@p_target_rank", MySqlDbType.Int32).Direction = ParameterDirection.Output;
    
                        cmd.ExecuteNonQuery();
    
                        object a = cmd.Parameters["@p_target_id"].Value;    // null 
                        object b = cmd.Parameters["@p_target_data"].Value;  // null
                        object c = cmd.Parameters["@p_target_rank"].Value;  // null =(
    
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Unexpected exception of type {ex.GetType()}: {ex.Message}");
                    return false;
                }
                finally
                {
                    conn?.Close();
                }
            }
