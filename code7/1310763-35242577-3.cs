        public int insertGetEntryID()
        {
            String sqlquery = "INSERT INTO maica (Lastname) VALUES ('" + textBox2.Text + "'); SELECT LAST_INSERT_ID();";
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
