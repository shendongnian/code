        public bool InitializeVariables(SqlDataReader sdr, bool isSingle = true)
        {
            try
            {
                if (sdr.HasRows)
                {
                    if (isSingle)
                        sdr.Read();
                    
                    //initialize and manipulate data here.
                    return true;
                }
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
