        public int getEntryID()
        {
            String sqlquery = "SELECT IDENT_CURRENT('maica')";
            SqlCommand command = new SqlCommand(sqlquery, sqlconn);
            try
            {
                sqlconn.Open();
                
                entryIdStr = command.ExecuteScalar().ToString();
                return int.Parse(entryIdStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return -1;
            }
            finally
            {
                sqlconn.Close();
            }
        }
