    public static bool isEmptySheet2(string nameSheet,OleDbConnection conn)
            {
    
            try
            {
                DataTable dt = new DataTable();
                string strSQL = "SELECT * FROM [" + nameSheet +"] WHERE [F17]='OK';";
                // string strSQL = "SELECT * FROM [" + "ThisIsSheet5$D4:D4" +"] WHERE [F17]='OK';";
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        //test for null here
                        if (row[col] != DBNull.Value)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            } return false;
    
    }
