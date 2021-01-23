        /// <summary>
        /// Process SQL script with "GO" statements 
        /// </summary>
        /// <param name="script"></param>
        public static void ProcessSQLScriptFile(string script)
        {
            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.SQLConDefault); // your connection string 
                con.Open(); 
                Server server = new Server(new ServerConnection(con));
                server.ConnectionContext.ExecuteNonQuery(script);
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Exception: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
