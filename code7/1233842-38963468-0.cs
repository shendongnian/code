     private static DataSet ExecuteFunction(string functionName)
        {
            DataSet ds = new DataSet();
            
            var conn = new NpgsqlConnection("replace with connection string");
            conn.Open();
            var tran = conn.BeginTransaction();
            var cmd = new NpgsqlCommand(functionName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(ds);
            //foreach (DataRow r in ds.Tables[0].Rows)
            //{
            //    Console.WriteLine("{0}", r[0]);
            //}
            tran.Commit();
            conn.Close();
            return ds;
        }
