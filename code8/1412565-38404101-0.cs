        public static DataTable SelectLastValueInTab(string TableName)
            {
                using (MySqlConnection con = new MySqlConnection(ConnStr))
                {
                    string qry = "SELECT * FROM" + TableName + "ORDER BY id DESC LIMIT 1";
                    using (MySqlCommand myCommand = new MySqlCommand(qry, con))
                    {
                        try
                        {
                            con.Open();
                            MySqlDataReader testreader = myCommand.ExecuteReader();
