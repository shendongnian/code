        public string[] Request(IDBConnection conn, string table, string condition, string columns, string sort)
        {
            List<string> output = new List<string>();
            string[] cols = columns.Split(',');
            string sql = string.Format("select * from {0} etc", table);
            using (IDBCommand cmd = new OracleCommand(conn, sql))
            {
                conn.Open();
                IDBReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foreach (string col in cols)
                    {
                        object field = reader.Item[col];
                        output.Add(field.ToString());
                    }
                }
            }
            return output.ToArray();
        }
