        public int execQuery(string sCmd, CommandType cmdType)
        {
            SqlCommand cmd = new SqlCommand(sCmd, m_sqlDataBase);
            cmd.CommandType = cmdType;
            try
            {
                m_sqlDataBase.Open();
            
                using(var dataReader = cmd.Execute())
                {
                    if (dataReader.Read())
                    {
                          return Convert.ToInt32(dataReader[0]);
                    }
                }
            }
            catch { 
                 // handle your error but don't trap it here..
                 throw;
            }
        }
