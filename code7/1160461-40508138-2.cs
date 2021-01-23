        public int Insert(int id, DTO mnemonics)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.CreateDefault();
            using (var dbCommand = Db.GetStoredProcCommand("spINSERT"))
            {
                using (var table = new DataTable())
                {
                    table.Columns.Add("Key", typeof(string));
                    table.Columns.Add("Value", typeof(string));
                    foreach (KeyValuePair<string, string> item in mnemonics.data)
                    {
                         var row = table.NewRow();
                         row["Key"] = item.Key;
                         row["Value"] = item.Value;
                         table.Rows.Add(row);
                    }
                    Db.AddInParameter(dbCommand, "id", DbType.int, id);
                    SqlParameter p = new SqlParameter("MNEMONICS", table);
                    p.SqlDbType = SqlDbType.Structured;
                    dbCommand.Parameters.Add(p);
                    Db.ExecuteNonQuery(dbCommand);
                }
            }
        }
