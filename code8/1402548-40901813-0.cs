    public static List<string> GetColumnNames(string queryString)
        {
            string result = string.Empty;
            List<string> listOfColumns = new List<string>();
            try
            {
                using (FbConnection conn = new FbConnection(connString))
                {
                    conn.Open();
                    using (FbCommand cmd = new FbCommand(queryString, conn))
                    {
                        // Call Read before accessing data.
                        FbDataReader reader = cmd.ExecuteReader();
                        if (reader.FieldCount > 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                listOfColumns.Add(reader.GetName(i));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                BinwatchLogging.Log(e);
            }
            return listOfColumns;
           // return result;
        }
