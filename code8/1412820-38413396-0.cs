            String connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0; Data    Source=Accounts.mdb";
            OleDbConnection conn = null;
            OleDbCommand cmd = null;
            OleDbDataReader rdr = null;
            String mySQL = "SELECT * FROM [user]";
            try
            {
                conn = new OleDbConnection(connectionstring);
                conn.Open();
               
                cmd = new OleDbCommand(mySQL, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.Write(String.Format("{0}\n,{1}\n", rdr.GetValue(0).ToString(), rdr.GetValue(1).ToString()));
                }
                Console.Read();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.Error.Write("Error founded: " + ex.Message);
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (cmd != null) cmd.Dispose();
                if (rdr != null) rdr.Dispose();
            }
