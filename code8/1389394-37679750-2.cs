            OracleConnection conn = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand(query, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                {
                    Console.WriteLine(reader[0]+"");
                }
