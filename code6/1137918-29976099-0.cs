        public static string DCAVACA(string badTable)
        {
            using (var olecon = new OleDbConnection(OLECONN)) // only change required for *syntactic* reasons
            {
                olecon.Open();
                deleteTable = new string[1] { "badTable" };
                for (int q = deleteTable.GetLowerBound(0); q <= deleteTable.GetUpperBound(0); q++)
                {
                    System.Data.OleDb.OleDbCommand cmd = new OleDbCommand("DROP TABLE " + deleteTable[q], olecon);
                    cmd.ExecuteNonQuery();
                }
            }
            return null;
        }
