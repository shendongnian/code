    using (MySqlTransaction tran = conn.BeginTransaction(System.Data.IsolationLevel.Serializable))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.Connection = conn;
            cmd.Transaction = tran;
            cmd.CommandText = "SELECT * FROM testtable";
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                da.UpdateBatchSize = 1000;
                using (MySqlCommandBuilder cb = new MySqlCommandBuilder(da))
                {
                    da.Update(rawData);
                    tran.Commit();
                }
            }
        }
    }
