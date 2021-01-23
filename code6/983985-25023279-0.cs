        public int execQuery(string sCmd, CommandType cmdType)
        {
            SqlCommand cmd = new SqlCommand(sCmd, m_sqlDataBase);
            cmd.CommandType = cmdType;
            try
            {
                m_sqlDataBase.Open();
            
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { 
                 // handle your error but don't trap it here..
                 throw;
            }
        }
     
