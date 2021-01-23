    public String[] StoredProcedureInOut(String procedureName, String[] values, String[] keys, String[] outputParameters)
        {
            openConnection();
            String[] newlyInsertedID = new String[outputParameters.Length];
            try
            {
                MySqlCommand cmd = new MySqlCommand(procedureName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < outputParameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + outputParameters[i], "0");
                    var parameterName = "@"+outputParameters[i];
                    cmd.Parameters[parameterName].Direction = ParameterDirection.Output;
                }
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + keys[i], values[i]);
                    var parameterName = "@" + keys[i];
                    cmd.Parameters[parameterName].Direction = ParameterDirection.Input;
                }
                //reader = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                for(int i = 0; i < outputParameters.Length; i++)
                {
                    var parameterName = "@"+outputParameters[i];
                    
                    newlyInsertedID[i] = cmd.Parameters[parameterName].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //reader = null;
            }
            closeConnection();
            return newlyInsertedID;
        }
